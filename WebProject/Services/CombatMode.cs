using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using WebProject.Data.Models;

namespace WebProject.Services
{
    public class CombatMode : ICombat
    {
        private readonly WebProjectDbContext _context;
        public CombatMode(WebProjectDbContext context)
        {
            _context = context;
        }



        public List<string> CombatLoop()
        {
            List<string> resultStringList = new List<string>();
            //Player stats
            int playerHitpoints = _context.Players.First().Hitpoints;
            int playerDamage = _context.Players.First().DamagePoints;
            string playerName = _context.Players.First().Name;
            int playerXp = _context.Players.First().Level;

            //Enemy stats
            int enemyId = _context.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().Id;
            int enemyHitpoints = _context.Enemies.Where(e => e.Id == enemyId).Select(e => e.Hitpoints).FirstOrDefault();
            

            //check if there is an enemy at all.
            if (enemyHitpoints == null)
            {
                resultStringList.Add("No enemy available for combat.");
                
                return resultStringList;
            }

            int enemyDamage = _context.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().DamagePoints;

            

            while (true)
            {

                enemyHitpoints -= playerDamage;
                resultStringList.Add($"Enemy was dealt {playerDamage} damage by {playerName}.");

                if (enemyHitpoints <= 0)
                {
                    //enemy dead, add xp, gold, loot, etc

                    _context.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().IsAlive = false;
                    _context.SaveChanges();

                   // _context.Players.First().Experience += _context; // Example XP gain
                    return resultStringList;
                    
                }

                playerHitpoints -= enemyDamage;
                if (playerHitpoints <= 0)
                {

                    //player dead, less gold, no xp, message
                    return resultStringList;
                }
             
                

            }
        }

      
    }
}

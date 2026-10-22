using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using WebProject.Data.Models;

namespace WebProject.Services
{
    public class CombatMode : ICombat
    {
        private readonly WebProjectDbContext dbContext;
        public CombatMode(WebProjectDbContext context)
        {
            this.dbContext = context;
        }


        /* 
           player stats to be determined by starting class, way to choose starting class on sign up.
           enemy stats to be determined by lvl, and updated on player defeating the list of monsters.
           have images tied to names of enemies, determined randomly?
         
         
         
         */
        public List<string> CombatLoop()
        {
            List<string> resultStringList = new List<string>();
            //Player stats
            int playerHitpoints = dbContext.Players.First().Hitpoints;
            int playerDamage = dbContext.Players.First().DamagePoints;
            string playerName = dbContext.Players.First().Name;
            int playerExperience = dbContext.Players.First().Experience;

            int playerGold = dbContext.Players.First().Gold;
            int playerLevel = dbContext.Players.First().Level;


            //Enemy stats , if enemy is returned null crashes. TO FIX.
            int? enemyId = dbContext.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().Id;
            

            //check if there is an enemy at all.
            if (enemyId == null)
            {
                resultStringList.Add("No enemy available for combat. Going deeper...");
                foreach (var enemy in dbContext.Enemies)
                {
                    enemy.IsAlive = true;
                }

                dbContext.SaveChanges();

                return resultStringList;
            }

            int enemyHitpoints = dbContext.Enemies.Where(e => e.Id == enemyId).Select(e => e.Hitpoints).FirstOrDefault();
            int enemyLevel = dbContext.Enemies.Where(e => e.Id == enemyId).OrderBy(e => e.Id).FirstOrDefault().Level;
            int enemyDamage = dbContext.Enemies.Where(e => e.Id == enemyId).Select(e => e.DamagePoints).FirstOrDefault();



            while (true)
            {

                enemyHitpoints -= playerDamage;
                resultStringList.Add($"Enemy was dealt {playerDamage} damage by {playerName}.");

                if (enemyHitpoints <= 0)
                {
                    //enemy dead, add xp, gold, loot, etc

                    dbContext.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().IsAlive = false;
                    

                    dbContext.Players.First().Experience += (enemyLevel * 5);
                    playerExperience += (enemyLevel * 5); // updating local 

                    dbContext.Players.First().Gold += (enemyLevel * 10);

                    if(playerExperience >= playerLevel * 10)
                    {
                        dbContext.Players.First().Level += 1;
                        dbContext.Players.First().Hitpoints += 10 * playerLevel;
                        dbContext.Players.First().DamagePoints += 1 * playerLevel;

                        resultStringList.Add($"Foe vanquished!");
                        resultStringList.Add($"{playerName} leveled up to level {playerLevel + 1}!");
                        resultStringList.Add($"{playerName}'s stats increased!");
                        


                    }

                    dbContext.SaveChanges();

                    return resultStringList;
                    
                }

                playerHitpoints -= enemyDamage;
                resultStringList.Add($"{playerName} was dealt {enemyDamage} damage by the enemy.");
                if (playerHitpoints <= 0)
                {
                    dbContext.Players.First().Gold += (enemyLevel * 5);
                    resultStringList.Add($"{playerName} managed to escape.");
                    //player dead, less gold, no xp, message
                    return resultStringList;
                }
             
                

            }
        }

      
    }
}

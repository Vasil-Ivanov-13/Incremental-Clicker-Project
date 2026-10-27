using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using WebProject.Data.Models;

namespace WebProject.Services
{
    public class CombatService 
    {
        private readonly WebProjectDbContext dbContext;
        
        public CombatService(WebProjectDbContext context)
        {
            this.dbContext = context;
           
        }


        /* 
           player stats to be determined by starting class, way to choose starting class on sign up.
           enemy stats to be determined by lvl, and updated on player defeating the list of monsters.
           have images tied to names of enemies, determined randomly?
         
         
         
         */
        public List<string> CombatLoop(string userId)
        {
            //List of strings to be represented in the view, something like a combat log.
            List<string> resultStringList = new List<string>();

            //check if there is an enemy at all.
            if (dbContext.Enemies.Any(e => e.IsAlive))
            {
                //Player stats start                

                Player currentPlayer = 
                    dbContext.Players
                    .First(p => p.UserId == userId);
                
                int playerHitpoints = currentPlayer.Hitpoints;

                int playerDamage = 0;

                string playerName = currentPlayer.Name;
                
                int playerExperience = currentPlayer.Experience;
          
                int playerLevel = currentPlayer.Level;
              
                //Player stats end


                //Enemy stats start

                Enemy currentEnemy = dbContext.Enemies
                    .Where(e => e.IsAlive)
                    .OrderByDescending(e => e.Id)
                    .First();


                int enemyHitpoints = currentEnemy.Hitpoints;
                
                int enemyLevel = currentEnemy.Level;
                
                int enemyDamage = currentEnemy.DamagePoints;

                //Enemy stats end

                //Combat loop start

                while (true)
                {
                    // Dice Rolls for player strength to determine player damage. 
                    //TODO add item calculations!!!
                    for (int i = 0; i < currentPlayer.Strength; i++)
                    {
                        playerDamage += Random.Shared.Next(1,7);       
                    }

                    enemyHitpoints -= playerDamage;

                    resultStringList.Add($"Enemy was dealt {playerDamage} damage by {playerName}.");
                    
                    //resetting player damage so new dice rolls can be clean.
                    playerDamage = 0;

                    if (enemyHitpoints <= 0)
                    {
                        //enemy dead, add xp, gold, loot, etc

                        currentEnemy.IsAlive = false;


                        currentPlayer.Experience += (enemyLevel * 3);
                        playerExperience += (enemyLevel * 3); // updating local 

                        currentPlayer.Gold += (enemyLevel * 10);
                        resultStringList.Add($"Foe vanquished!");

                        if (currentPlayer.Experience >= currentPlayer.Level * 10)
                        {
                            currentPlayer.Experience = playerExperience - (currentPlayer.Level * 10);
                            currentPlayer.Hitpoints += 10 * playerLevel;
                            currentPlayer.Level += 1;

                            playerLevel += 1; // updating local
                           
                            

                            
                            resultStringList.Add($"{playerName} leveled up to level {playerLevel}!");
                            resultStringList.Add($"{playerName}'s stats increased!");

                            currentPlayer.Experience = playerExperience ;

                        }

                        dbContext.SaveChanges();

                        return resultStringList;

                    }

                    playerHitpoints -= enemyDamage;
                    resultStringList.Add($"{playerName} was dealt {enemyDamage} damage by the enemy.");
                    if (playerHitpoints <= 0)
                    {
                        resultStringList.Add($"{playerName} was nearly killed...");
                        currentPlayer.Gold += (enemyLevel);
                        resultStringList.Add($"{playerName} managed to escape.");
                        //player dead, less gold, no xp, message
                        dbContext.SaveChanges();
                        return resultStringList;
                    }



                }

                //Combat loop end

            }
            else
            {
                //Going deeper would mean adding another enemy to the list.
                //That will happen with random class after some balancing math is done.Not urgent.
                //Enemy stats will be generated based on enemy level.
                resultStringList.Add("No enemy available for combat. Going deeper...");
                foreach (Enemy e in dbContext.Enemies)
                {
                    e.IsAlive = true;
                    e.Level += 1;
                }

                dbContext.SaveChanges();

                return resultStringList;
            }

            
        }

    }
}

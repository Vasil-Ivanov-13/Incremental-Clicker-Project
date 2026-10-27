using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.Services.Interfaces;

namespace WebProject.Services
{
    public class CombatService : ICombatService
    {
        private readonly WebProjectDbContext dbContext;
        
        public CombatService(WebProjectDbContext context)
        {
            this.dbContext = context;
           
        }
        public List<string> CombatLoop(string userId)
        {
            //List of strings to be represented in the view, something like a combat log.
            List<string> resultStringList = new List<string>();
            Player currentPlayer = dbContext.Players
                    .Include(p => p.WeaponItem)
                    .Include(p => p.ArmourItem)
                    .First(p => p.UserId == userId);
            int playerLevel = currentPlayer.Level;
            //check if there is an enemy at all.
            if (dbContext.Enemies.Any(e => e.IsAlive))
            {
                //Player stats start                

                

                int? playerHitpoints = currentPlayer.Hitpoints;

                if(currentPlayer.ArmourItem != null)
                {
                    playerHitpoints += currentPlayer.ArmourItem.HealthPoints;
                }

                string playerName = currentPlayer.Name;
                
                int playerExperience = currentPlayer.Experience;
          
                

                int playerStrength = currentPlayer.Strength;

                int playerDamage = 0;

                if (currentPlayer.WeaponItem != null)
                {
                    playerDamage = currentPlayer.WeaponItem.DamagePoints;
                }

                //Player stats end


                //Enemy stats start

                Enemy currentEnemy = dbContext.Enemies
                    .Where(e => e.IsAlive)
                    .OrderBy(e => e.Id)
                    .First();


                int enemyHitpoints = currentEnemy.Hitpoints;
                
                int enemyLevel = currentEnemy.Level;
                
                int enemyDamage = currentEnemy.DamagePoints;

                //Enemy stats end

                //Combat loop start
                int playerInstanceDamage = 0;

                while (true)
                {
                    playerInstanceDamage = playerDamage + PlayerDealDamage(playerStrength);
                    
                    enemyHitpoints -= playerInstanceDamage;

                    resultStringList.Add($"Enemy was dealt {playerInstanceDamage} damage by {playerName}.");
                    

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

                dbContext.Enemies.RemoveRange(dbContext.Enemies);
                for (int i = 0; i < 5; i++)
                {
                   Enemy enemy = GenerateEnemy(playerLevel, i);
                    dbContext.Enemies.Add(enemy);


                }

                dbContext.SaveChanges();

                return resultStringList;
            }

            
        }
        private int PlayerDealDamage(int strength)
        {
            int damage = 0;
            for (int i = 0; i < strength; i++)
            {
                damage += Random.Shared.Next(1, 7);
            }



            return damage;
        }

        private Enemy GenerateEnemy(int playerLevel, int iterator)
        {
            int enemyLevel = Random.Shared.Next(1, playerLevel + iterator);
            Enemy genEnemy = new()
            {
                Level = enemyLevel,
                DamagePoints = playerLevel + enemyLevel,
                Hitpoints = 10 + enemyLevel * 10,
                IsAlive = true,

            };
            return genEnemy;
        }


    }
}

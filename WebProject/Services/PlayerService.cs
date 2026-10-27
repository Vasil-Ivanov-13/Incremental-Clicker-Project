using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.Services.Interfaces;
using WebProject.ViewModels;
using static WebProject.Common.EntityValidations;

namespace WebProject.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly WebProjectDbContext dbContext;
        public PlayerService(WebProjectDbContext context)
        {
            this.dbContext = context;
        }
        public bool UserHasCharacter(string userId)
        {
            bool result =
                dbContext
                .Players
                .Any(p => p.UserId == userId);

                return result;
        }

        public void CreateCharacter(string userId, CreatePlayerViewModel model)
        {
            int strength = 0;
            int health = 0;

            switch (model.CharacterClass)
            {
                case Data.Enums.ClassEnums.Basic:
                    strength = BasicStrength;
                    health = BasicHealth;
                    break;
                case Data.Enums.ClassEnums.Warrior:
                    strength = WarriorStrength;
                    health = WarriorHealth;
                    break;
                case Data.Enums.ClassEnums.Rogue:
                    strength = RogueStrength;
                    health = RogueHealth;
                    break;
                default:
                    
                    break;
            }
            Player player = new()
            {
                Name = model.Name,
                CharacterType = model.CharacterClass,
                UserId = userId,
                ArmourItem = null,
                WeaponItem = null,
                Experience = 0,
                Gold = 0,
                Hitpoints = health,
                Level = 1,
                Strength = strength

            };

            dbContext.Players.Add(player);
            dbContext.Enemies.RemoveRange(dbContext.Enemies);
            dbContext.SaveChanges();



        }
        
        public void RemoveCharacter(string userId)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);
            if(currentPlayer.WeaponItem != null)
            {
                dbContext.WeaponItems.Remove(currentPlayer.WeaponItem);
            }

            if(currentPlayer.ArmourItem != null)
            {
                dbContext.ArmourItems.Remove(currentPlayer.ArmourItem);
            }
            dbContext.Players.Remove(currentPlayer);
            dbContext.SaveChanges();

        }

        public void RenameCharacter(string userId, string rename)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);
            currentPlayer.Name = rename;
            dbContext.SaveChanges();

        }

        public PlayerStatsViewModel GetStatusPage(string userId)
        {
            Player player = dbContext.Players
        .Include(p => p.WeaponItem)
        .Include(p => p.ArmourItem)
        .First(p => p.UserId == userId);


            PlayerStatsViewModel statusPage = new()
            {
                Player = new ShowPlayerViewModel
                {
                    Name = player.Name,
                    CharacterClass = player.CharacterType,
                    PlayerHealth = player.Hitpoints,
                    PlayerStrength = player.Strength,
                    PlayerLevel = player.Level,
                    PlayerExperience = player.Experience,
                    PlayerGold = player.Gold
                }
            };

            if (player.WeaponItem != null)
            {
                statusPage.Weapon = new ShowWeaponViewModel
                {
                    Name = player.WeaponItem.ItemName,
                    WeaponDamage = player.WeaponItem.DamagePoints,
                    WeaponStrength = player.WeaponItem.StrengthModifier
                };
            }

            if (player.ArmourItem != null)
            {
                statusPage.Armour = new ShowArmourViewModel
                {
                    Name = player.ArmourItem.ItemName,
                    ArmourHealth = player.ArmourItem.HealthPoints
                };
            }

            return statusPage;
        }
    }
    
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Reflection.Metadata.Ecma335;
using WebProject.Data.Models;
using WebProject.ViewModels;
using static WebProject.Common.EntityValidations;

namespace WebProject.Services
{
    public class PlayerService
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
            dbContext.SaveChanges();



        }
        //TODO
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
            //check if the playerid value is removed auto from the users table later, could be a bug
        }

        public void RenameCharacter(string userId, string rename)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);
            currentPlayer.Name = rename;
            dbContext.SaveChanges();
            //to validate on other end for string data.
        }
    }
}

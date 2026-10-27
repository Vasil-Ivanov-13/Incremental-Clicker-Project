using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.Services.Interfaces;
using WebProject.ViewModels;
using static WebProject.Common.EntityValidations;
namespace WebProject.Services
{
    public class ShopService: IShopService
    {

        private readonly WebProjectDbContext dbContext;
        public ShopService(WebProjectDbContext context)
        {
            this.dbContext = context;
        }

        public bool BuyDamageUpgrade(string userId)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);

            if(currentPlayer.Gold < DamageCost)
            {
                return false;
            }
            else 
            {
                currentPlayer.Gold -= DamageCost;
                currentPlayer.Strength += StrengthIncrement;
                dbContext.SaveChanges();
                return true;
            }
            
            

        }

        public bool BuyHealthUpgrade(string userId)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);

            if (currentPlayer.Gold < HealthCost)
            {
                return false;
            }
            else
            {
                currentPlayer.Gold -= HealthCost;
                currentPlayer.Hitpoints += HealthIncrement;
                dbContext.SaveChanges();
                return true;
            }

        }
        public bool CraftWeapon(string userId, CraftWeaponViewModel model)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.Gold < WeaponCost || currentPlayer.WeaponItem != null)
            {
                return false;
            }
            else
            {
                int itemDamage = Random.Shared.Next(ItemMinDamage, ItemMaxDamage + 1);
                int itemStrength = Random.Shared.Next(ItemStrengthModifierMinValue, ItemStrengthModifierMaxValue + 1);


                WeaponItem weapon = new()
                {
                    ItemName = model.ItemName,
                    PlayerId = currentPlayer.Id,
                    DamagePoints = itemDamage,
                    StrengthModifier = itemStrength,
                    Player = currentPlayer
                };
                dbContext.WeaponItems.Add(weapon);
                currentPlayer.Gold -= WeaponCost;
                dbContext.SaveChanges();
                return true;
            }
            

        }
        public bool CraftArmour(string userId, CraftArmourViewModel model)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.Gold < ArmourCost || currentPlayer.ArmourItem != null)
            {
                return false;
            }
            else
            {
                int itemHealth = Random.Shared.Next(ItemMinHealth, ItemMaxHealth + 1);

                ArmourItem armour = new()
                {
                    ItemName = model.ItemName,
                    PlayerId = currentPlayer.Id,
                    HealthPoints = itemHealth,
                    Player = currentPlayer
                    
                };
                dbContext.ArmourItems.Add(armour);
                currentPlayer.Gold -= ArmourCost;
                dbContext.SaveChanges();
                return true;
            }



        }

        public bool RemoveWeapon(string userId)
        {

            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.WeaponItem == null)
            {
                return false;
            }
            else
            {
                WeaponItem weapon = currentPlayer.WeaponItem; 
                dbContext.WeaponItems.Remove(weapon);
                currentPlayer.WeaponItem = null;

                dbContext.SaveChanges();
                return true;
            }
            
        }
        public bool RemoveArmour(string userId)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.ArmourItem == null)
            {
                return false;
            }
            else
            {
                ArmourItem armour = currentPlayer.ArmourItem;
                dbContext.ArmourItems.Remove(armour);
                currentPlayer.ArmourItem = null;

                dbContext.SaveChanges();
                return true;
            }

        }
        //Not Implemented in controllers and views.
        public bool RenameWeapon(string userId, string itemRename)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.WeaponItem == null)
            {
                return false;
            }
            else
            {
                WeaponItem weapon = currentPlayer.WeaponItem;
                weapon.ItemName = itemRename;
                dbContext.SaveChanges();
                return true;
            }
        }
        //Not Implemented in controllers and views.
        public bool RenameArmour(string userId, string itemRename)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.ArmourItem == null)
            {
                return false;
            }
            else
            {
                ArmourItem armour = currentPlayer.ArmourItem;
                armour.ItemName = itemRename;
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.ViewModels;
using static WebProject.Common.EntityValidations;
namespace WebProject.Services
{
    public class ShopService
    {

        private readonly WebProjectDbContext dbContext;
        public ShopService(WebProjectDbContext context)
        {
            this.dbContext = context;
        }

        public void BuyDamageUpgrade(string userId)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);

            if(currentPlayer.Gold < DamageCost)
            {
                //logic for not enough gold error tba
            }
            else 
            {
                currentPlayer.Gold -= DamageCost;
                currentPlayer.Strength += StrengthIncrement;
                dbContext.SaveChanges();
            }
            
            

        }

        public void BuyHealthUpgrade(string userId)
        {
            Player currentPlayer = dbContext.Players.First(p => p.UserId == userId);

            if (currentPlayer.Gold < HealthCost)
            {
                //logic for not enough gold error tba
            }
            else
            {
                currentPlayer.Gold -= HealthCost;
                currentPlayer.Hitpoints += HealthIncrement;
                dbContext.SaveChanges();
            }

        }
        public void CraftWeapon(string userId, CraftWeaponViewModel model)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.Gold < WeaponCost)
            {
                //not enough gold message tba
            }
            else if (currentPlayer.WeaponItem == null)
            {
                int itemDamage = Random.Shared.Next(ItemMinDamage, ItemMaxDamage);
                int? itemStrength = Random.Shared.Next(ItemStrengthModifierMinValue, ItemStrengthModifierMaxValue);
                if (itemStrength == 0)
                {
                    itemStrength = null;
                }

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
            }
            

        }
        public void CraftArmour(string userId, CraftArmourViewModel model)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.Gold < ArmourCost)
            {
                //not enough gold message tba
            }
            else if(currentPlayer.ArmourItem == null)
            {
                int itemHealth = Random.Shared.Next(ItemMinHealth, ItemMaxHealth);

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
            }



        }

        public void RemoveWeapon(string userId)
        {

            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.WeaponItem == null)
            {

            }
            else
            {
                WeaponItem weapon = currentPlayer.WeaponItem;//dbContext.WeaponItems.Where(w => w.PlayerId == currentPlayer.Id).First(); TO FIX EVERYWHERE 
                dbContext.WeaponItems.Remove(weapon);
                currentPlayer.WeaponItem = null;

                dbContext.SaveChanges();
            }
            
        }
        public void RemoveArmour(string userId)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.ArmourItem == null)
            {

            }
            else
            {
                ArmourItem armour = dbContext.ArmourItems.Where(a => a.PlayerId == currentPlayer.Id).First();
                dbContext.ArmourItems.Remove(armour);
                currentPlayer.ArmourItem = null;

                dbContext.SaveChanges();
            }

        }
        public void RenameWeapon(string userId, string itemRename)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.WeaponItem).First(p => p.UserId == userId);
            if (currentPlayer.WeaponItem == null)
            {
                //no item to remove
            }
            else
            {
                WeaponItem weapon = dbContext.WeaponItems.Where(w => w.PlayerId == currentPlayer.Id).First();
                weapon.ItemName = itemRename;
                dbContext.SaveChanges();
            }
        }
        public void RenameArmour(string userId, string itemRename)
        {
            Player currentPlayer = dbContext.Players.Include(p => p.ArmourItem).First(p => p.UserId == userId);
            if (currentPlayer.ArmourItem == null)
            {
                //no item to remove
            }
            else
            {
                ArmourItem armour = dbContext.ArmourItems.Where(w => w.PlayerId == currentPlayer.Id).First();
                armour.ItemName = itemRename;
                dbContext.SaveChanges();
            }
        }
    }
}

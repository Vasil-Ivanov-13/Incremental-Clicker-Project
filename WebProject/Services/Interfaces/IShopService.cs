using WebProject.ViewModels;

namespace WebProject.Services.Interfaces
{
    public interface IShopService
    {
        bool BuyDamageUpgrade(string userId);
        bool BuyHealthUpgrade(string userId);
        bool CraftWeapon(string userId, CraftWeaponViewModel model);
        bool CraftArmour(string userId, CraftArmourViewModel model);
        bool RemoveWeapon(string userId);
        bool RemoveArmour(string userId);
        bool RenameWeapon(string userId, string itemRename);
        bool RenameArmour(string userId, string itemRename);
    }
}

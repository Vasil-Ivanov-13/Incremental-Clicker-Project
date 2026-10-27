using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Data.Models;
using WebProject.Services;
using WebProject.ViewModels;
namespace WebProject.Controllers
{
    public class ShopController : StartController
    {
        private readonly ShopService shopService;
        private readonly PlayerService playerService;
        public ShopController(ShopService shopService, PlayerService playerService )
        {
            this.shopService = shopService;
            this.playerService = playerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /* post method to handle item crafting. Get method to display the crafting page.
         (with options and drawdown menu that logically builds items according to slots.

         How to deal with an item slot being taken? Add them to the player model?
         Or web validation that something exists in that "slot" and if it is taken allow removal.
        
        !!!Leaning towards player model having individual properties per item slot.
        View would pull the items and display them if not null.
        When null, allow crafting. When not, allow removal.(returning portion of cost)

        If player has an item slot filled, their total values will be modified with item values in db.

        If item removed, total item values will be subtracted.

        Is that a good approach? Add Inventory model with list of item slots. Relation to player with id fk, 1-1. 
        But then the calculations get more complicated from model to model.
        */
        [Authorize]
        [HttpGet]
        public IActionResult CraftWeapon()
        {
            if (!playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("Index");
            }

            return View(new CraftWeaponViewModel());
        }
        [Authorize]
        [HttpPost]
        public IActionResult CraftWeapon(CraftWeaponViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            shopService.CraftWeapon(userId, model);

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult CraftArmour()
        {
            if (!playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("Index");
            }

            return View(new CraftArmourViewModel());
        }
        [Authorize]
        [HttpPost]
        public IActionResult CraftArmour(CraftArmourViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            shopService.CraftArmour(userId, model);

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult UpgradeDamage()
        {
            
            shopService.BuyDamageUpgrade(userId);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult UpgradeHealth()
        {
           
            shopService.BuyHealthUpgrade(userId);

            return RedirectToAction("Index");
        }

        
    }
}

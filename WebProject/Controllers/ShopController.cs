using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Interfaces;
using WebProject.ViewModels;
namespace WebProject.Controllers
{
    public class ShopController : StartController
    {
        private readonly IShopService shopService;
        private readonly IPlayerService playerService;
        public ShopController(IShopService shopService, IPlayerService playerService )
        {
            this.shopService = shopService;
            this.playerService = playerService;
        }
        public IActionResult Index()
        {
            return View();
        }
     
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!shopService.CraftWeapon(userId, model))
            {
                ModelState.AddModelError(string.Empty, "Not enough gold, or you already have a weapon.");
                return View(model);
            }

            TempData["Success"] = "Weapon crafted!";
            return RedirectToAction("PlayerDetails", "Player");
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!shopService.CraftArmour(userId, model))
            {
                ModelState.AddModelError(string.Empty, "Not enough gold, or you already have armor.");
                return View(model);
            }

            TempData["Success"] = "Armour crafted!";
            return RedirectToAction("PlayerDetails","Player");
        }
        [Authorize]
        public IActionResult UpgradeDamage()
        {
            if (!shopService.BuyDamageUpgrade(userId))
            {
                TempData["Error"] = "Not enough gold.";
            }
            
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult UpgradeHealth()
        {
            if (!shopService.BuyHealthUpgrade(userId))
            {
                TempData["Error"] = "Not enough gold.";
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult RemoveWeapon()
        {
            if (shopService.RemoveWeapon(userId))
            {
                TempData["Success"] = "Weapon removed.";
            }

            return RedirectToAction("CraftWeapon");
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveArmour()
        {
            if (shopService.RemoveArmour(userId))
            {
                TempData["Success"] = "Armour removed.";
            }

            return RedirectToAction("CraftArmour");
        }


    }
}

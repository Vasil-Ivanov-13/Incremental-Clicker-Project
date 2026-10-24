using Microsoft.AspNetCore.Mvc;
using WebProject.Services;
using WebProject.Data.Models;
namespace WebProject.Controllers
{
    public class ShopController : Controller
    {


        private readonly WebProjectDbContext dbContext;
        //private readonly CraftItemMode crafter; 
        public ShopController(WebProjectDbContext context)
        {
            dbContext = context;
            

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
        public IActionResult CraftItem1()
        {
            
            return View();
        }

        public IActionResult CraftItem2()
        {

            return View();
        }

        public IActionResult UpgradeDamage()
        {
            new ShopService(dbContext).BuyDamageUpgrade();
            return RedirectToAction("Index");
        }

        public IActionResult UpgradeHealth()
        {


            return RedirectToAction("Index");
        }
    }
}

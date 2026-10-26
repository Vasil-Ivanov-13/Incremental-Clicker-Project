using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Data.Models;
using WebProject.Services;

namespace WebProject.Controllers
{
    public class GameScreenController : Controller
    {
        private readonly PlayerService playerService;

        private readonly CombatService combat;

        public GameScreenController(PlayerService userService, CombatService combat)
        {
           
            this.playerService = userService;
            this.combat = combat;

        }
         
        public IActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        public IActionResult Combat()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("No logged in user found.");
          
            if (!playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("Index");
            }
            combat.CombatLoop(userId);
            // add an endless enemy generation loop, where dead enemies level up and a new enemy is generated
            //when the enemy list ends.

            return RedirectToAction("Index");
        }


    }
}

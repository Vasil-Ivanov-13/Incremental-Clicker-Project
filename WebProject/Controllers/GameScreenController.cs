using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Interfaces;


namespace WebProject.Controllers
{
    public class GameScreenController : StartController
    {
        private readonly ICombatService combat;
        private readonly IPlayerService playerService;

        public GameScreenController(ICombatService combat, IPlayerService playerService)
        {
            this.combat = combat;
            this.playerService = playerService;
        }  
        public IActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        public IActionResult Combat()
        {

            
          
            if (!playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("CreatePlayer");
            }
            List<string> combatLog = combat.CombatLoop(userId);
            // add an endless enemy generation loop, where dead enemies level up and a new enemy is generated
            //when the enemy list ends.

            return View(combatLog);
        }

    }
}

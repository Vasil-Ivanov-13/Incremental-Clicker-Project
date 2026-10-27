using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Data.Models;
using WebProject.Services;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class GameScreenController : StartController
    {
        private readonly PlayerService playerService;

        private readonly CombatService combat;

        public GameScreenController(PlayerService playerService, CombatService combat)
        {
           
            this.playerService = playerService;
            this.combat = combat;

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
            combat.CombatLoop(userId);
            // add an endless enemy generation loop, where dead enemies level up and a new enemy is generated
            //when the enemy list ends.

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePlayer()
        {
            if (playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("Index");
            }

            return View(new CreatePlayerViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            playerService.CreateCharacter(userId, model);

            return RedirectToAction("Index");
        }

    }
}

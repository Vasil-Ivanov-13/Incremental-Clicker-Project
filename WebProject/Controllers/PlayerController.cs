using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Interfaces;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class PlayerController : StartController
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePlayer()
        {
            if (playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("PlayerDetails");
            }

            return View(new CreatePlayerViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            playerService.CreateCharacter(userId, model);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemovePlayer()
        {
            if (playerService.UserHasCharacter(userId))
            {
                playerService.RemoveCharacter(userId);
            }
            return RedirectToAction("CreatePlayer");
        }


        [Authorize]
        [HttpGet]
        public IActionResult PlayerDetails()
        {
            if (!playerService.UserHasCharacter(userId))
            {
                return RedirectToAction("CreatePlayer");
            }

            PlayerStatsViewModel model = playerService.GetStatusPage(userId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult RenamePlayer(RenameViewModel model)
        {
            if (playerService.UserHasCharacter(userId))
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Name must be between 2 and 15 characters.";
                    return RedirectToAction("PlayerDetails");
                }

                playerService.RenameCharacter(userId, model.NewName);
                TempData["Success"] = "Character renamed.";

                
            }
            return RedirectToAction("PlayerDetails");
        }



    }
}

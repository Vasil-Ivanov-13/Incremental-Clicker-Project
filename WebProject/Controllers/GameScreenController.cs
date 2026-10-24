using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.Services;

namespace WebProject.Controllers
{
    public class GameScreenController : Controller
    {
        private readonly WebProjectDbContext dbContext;
        
        public GameScreenController(WebProjectDbContext context)
        {
            dbContext = context;
            
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Combat()
        {
            new CombatService(dbContext).CombatLoop();
            // add an endless enemy generation loop, where dead enemies level up and a new enemy is generated
            //when the enemy list ends.

            return RedirectToAction("Index");
        }
    }
}

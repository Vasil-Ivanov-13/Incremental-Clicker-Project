using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;

namespace WebProject.Controllers
{
    public class GameScreenController : Controller
    {
        private readonly WebProjectDbContext _context;
        public GameScreenController(WebProjectDbContext context)
        {
            _context = context; 
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Combat()
        {
           /* Random random = new Random(); 
            * 
            * ADD rng to combat utilising dice rolls using str stat?
            
            */
           
            int playerHitpoints = _context.Players.First().Hitpoints;
            int? enemyHitpoints = _context.Enemies.Where(e => e.IsAlive).FirstOrDefault().Hitpoints;
            int playerDamage = _context.Players.First().DamagePoints;
            int enemyDamage = _context.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().DamagePoints;
            string viewMessage = string.Empty;

            if (enemyHitpoints == null)
            {
                return RedirectToAction("Index", "Home");
            }



            while (playerHitpoints > 0 && enemyHitpoints > 0)
            {
                
                enemyHitpoints -= playerDamage;
                
                if(enemyHitpoints <= 0)
                {
                    //enemy dead, add xp, gold, loot, etc
                    viewMessage = "Player won";
                    _context.Enemies.Where(e => e.IsAlive).OrderBy(e => e.Id).FirstOrDefault().IsAlive = false;
                    _context.SaveChanges();
                    break;
                }

                playerHitpoints -= enemyDamage;
                if(playerHitpoints <= 0)
                {
                    viewMessage = "Enemy won";
                    //player dead, less gold, no xp, message
                    
                }
            }
           // ViewData["Message"] = viewMessage;

            return RedirectToAction("Index");
        }
    }
}

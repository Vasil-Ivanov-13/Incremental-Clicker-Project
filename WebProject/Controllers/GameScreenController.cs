using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class GameScreenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

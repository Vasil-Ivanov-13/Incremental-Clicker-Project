using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

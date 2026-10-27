using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebProject.Controllers
{
    public abstract class StartController : Controller
    {
        protected string userId => 
            User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("No logged in user found.");





    }
}

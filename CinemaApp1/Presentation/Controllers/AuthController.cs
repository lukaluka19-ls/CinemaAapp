using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View(
                );
        }
    }
}

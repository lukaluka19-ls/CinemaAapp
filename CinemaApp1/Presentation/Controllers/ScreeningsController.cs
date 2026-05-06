using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class ScreeningsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

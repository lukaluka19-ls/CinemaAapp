using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

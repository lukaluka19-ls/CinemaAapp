using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

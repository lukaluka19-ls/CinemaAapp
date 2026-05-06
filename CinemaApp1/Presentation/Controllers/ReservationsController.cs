using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class ReservationController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

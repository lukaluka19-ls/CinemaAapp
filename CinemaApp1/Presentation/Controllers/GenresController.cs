using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _service;
        public GenresController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _service.GetAllAsync();
            return View(genres);
        }

    } 
}
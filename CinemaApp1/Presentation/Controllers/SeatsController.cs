using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Presentation.Controllers
{
    public class SeatsController : Controller
    {
        private readonly ISeatService _service;
        public SeatsController(ISeatService service) =>
            _service = service;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}

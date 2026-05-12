using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rating = await _ratingService.GetAllAsync();
            return Ok(rating);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var rating = await _ratingService.GetByIDAsync(id);
            if(rating == null)
                return NotFound();
            return Ok(rating);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RatingCreateDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _ratingService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ReservationId }, created);
        }

    }
}

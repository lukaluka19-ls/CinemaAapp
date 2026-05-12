using CinemaApp1.Application.Services.Implementation;
using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _movieService;

        public MovieController(IMoviesService movieservice)
        {
            _movieService = movieservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _movieService.GetAllAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await _movieService.GetByIDAsync(id);
            if (genre == null)
                return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _movieService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GenreId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _movieService.UpdateAsync(id, dto);
            //if (!result)
                //return NoContent();
            return NotFound();

        }

    }
}
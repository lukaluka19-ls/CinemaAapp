using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningsController : ControllerBase
    {
        private readonly IScreeningService _screeningService;

        public ScreeningsController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ScreeningFilterDTO filter)
        {
            var screenings = await _screeningService.GetScreeningListAsync(filter);
            return Ok(screenings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var screening = await _screeningService.GetScreeningByIdAsync(id);
            if (screening == null)
                return NotFound();
            return Ok(screening);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ScreeningCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _screeningService.CreateScreeningAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.MovieId }, created);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ScreeningUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _screeningService.UpdateScreeningAsync(id, dto);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _screeningService.DeleteScreeningAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
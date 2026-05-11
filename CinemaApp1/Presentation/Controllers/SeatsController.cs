using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class SeatsController : ControllerBase
    {
        public readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById()
        {
            var seats = await _seatService.GetAllAsync();
            if (seats == null)
                return NotFound();
            return Ok(seats);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeatCreateDTO dTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _seatService.CreateSeatAsync(dTO);
            return CreatedAtAction(nameof(GetById), new { id = created.Id });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservation = await _reservationService.GetAllAsync();
            return Ok(reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _reservationService.GetByIDAsync(id);
            if(reservation == null) 
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateReservationDTO dTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _reservationService.CreateAsync(dTO);
            //return CreatedAtAction(nameof(GetById), new {})
        }

    }
}

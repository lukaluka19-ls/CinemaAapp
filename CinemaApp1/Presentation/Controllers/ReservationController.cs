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
        //[Authorize(Roles = "Consumer")]
        public async Task<IActionResult> GetAll()
        {
            var reservation = await _reservationService.GetAllAsync();
            return Ok(reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _reservationService.GetByIDAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        //[Authorize(Roles = "Consumer")]
        public async Task<IActionResult> Create(CreateReservationDTO dto)
        {
            var created = await _reservationService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Consumer")]
        public async Task<IActionResult> GetDeatailById(int id)
        {
            var reservation = await _reservationService.GetDetailAsync(id);
            return Ok(reservation);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListAsyncId(int userId)
        {
            var reservation = await _reservationService.GetListAsync(userId);
            return Ok(reservation);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Consumer")]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationService.DeleteReservationAsync(id);
            if(!reservation)
                return NotFound();
            return NoContent();

        }


        //[HttpPut("{id}")]
        ////[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Update(int id, [FromBody] UpdateReser dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _reservationService.(id, dto);
        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        ////[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _re.DeleteScreeningAsync(id);
        //    if (!result)
        //        return NotFound();

        //    return NoContent();
    }
}

using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserAccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var consumers = await _usersService.GetAllUsersAsync();
            return Ok(consumers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetUserById(int id)
        {
            var consumer = await _usersService.GetUserById(id);
            return Ok(consumer);
        }
        [HttpPost("{id}/block")]
        public async Task<IActionResult>BlockUser(int id)
        {
            await _usersService.BlockUserAsync(id);
            return Ok("Consumer is blocked successfully");
        }
        [HttpPost("{id}/unblock")]
        public async Task<IActionResult> UnblockUser(int id)
        {
            await _usersService.UnblockUserAsync(id);
            return Ok("Consumer is unblocked successfully");
        }
    }
}

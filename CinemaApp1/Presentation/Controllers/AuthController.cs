using CinemaApp1.Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService) =>
            _jwtService = jwtService;

        [Authorize]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var response = await _jwtService.Authenticate(request);
            if (response == null)
                return Unauthorized(new { message = "Invalid username or password" });
            return Ok(response);
        }

        //[Authorize]
        //[HttpPost("register")]

        //public async Task<IActionResult> Register(RegisterDTO request)
        //{
        //    var response = await _jwtService.Register(request);
        //    if (response == null)
        //        return BadRequest(new { message = "User already exists" });
        //    return Ok(response);
        //}
    }
}

using CinemaApp1.Presentation.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public AuthController(JwtService jwtService) =>
            _jwtService = jwtService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult><LoginResponseModel>>Login(LoginRequestModel request)
        {
            var response = await _jwtService.Authenticate(request);
            if (response == null)
                return Unauthorized(new { message = "Invalid username or password" });
            return Ok(response);
        }
}

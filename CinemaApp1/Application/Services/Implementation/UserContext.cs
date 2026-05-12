using CinemaApp1.Application.Services.Interfaces;
using System.Security.Claims;

namespace CinemaApp1.Application.Services.Implementation
{
    public class UserContext: IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public int? UserId
        {
            get
            {
                var value = User?
                    .FindFirst(ClaimTypes.NameIdentifier)?
                    .Value;
                return int.TryParse(value, out var id)?id: null;
            }
        }
        public string? Email => 
            User?.FindFirst(ClaimTypes.Email)?.Value;

        public string? Role =>
            User?.FindFirst(ClaimTypes.Role)?.Value;

        public bool isAuthenticated =>
            User?.Identity?.IsAuthenticated ?? false;
    }
}

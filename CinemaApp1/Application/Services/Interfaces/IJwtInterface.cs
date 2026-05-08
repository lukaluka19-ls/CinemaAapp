namespace CinemaApp1.Infrastructure.Auth
{
    public interface IJwtService
    {
        Task<AuthResponseDto?> Authenticate(LoginDTO request);
    }
}
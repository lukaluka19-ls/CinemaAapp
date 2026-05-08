public interface IJwtService
{
    Task<AuthResponseDto?> Authenticate(LoginDTO request);
}
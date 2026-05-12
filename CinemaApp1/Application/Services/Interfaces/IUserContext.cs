namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IUserContext
    {
        int? UserId { get; }
        string? Email { get; }
        string? Role { get; }
        bool isAuthenticated { get; }
    }
}

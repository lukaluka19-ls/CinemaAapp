namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDTO dto);
        Task<bool> VerifyEmailAsync(string token);
        Task ForgotPasswordAsync(ForgotPasswordDTO dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO dto);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO dto);
    }
}
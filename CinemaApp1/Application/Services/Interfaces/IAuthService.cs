namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IEnumerable<AuthResponseDto>> GetAllAsync();
        Task<AuthResponseDto> GetByIDAsync(int id);
        Task<RegisterDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<LoginDTO> LoginAsync(LoginDTO loginDTO);
        Task<ChangePasswordDTO> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
        Task<ForgotPasswordDTO> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO);
        Task<ResetPasswordDTO> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
        Task<UserResponseDto> GetCurrentUserAsync(int id);
        Task<VerifyEmailResponseDto> VerifyEmailAsync(VerifyEmailResponseDto verifyEmailDTO);




    }
}

using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Domain.Models;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IMapper mapper,
            IUserRepository userRepository,
            IPasswordHashService passwordHashService,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(RegisterDTO dto)
        {
            var exists = await _userRepository.AnyAsync(u => u.Email == dto.Email);
            if (exists) return false;

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = _passwordHashService.Hash(dto.Password);
            user.Role = (int)UserRole.Consumer;
            user.IsVerified = false;
            user.IsBlocked = false;
            user.VerificationToken = Guid.NewGuid().ToString("N");

            await _userRepository.AddAsync(user);

            var verificationLink = $"{_configuration["AppUrl"]}/api/auth/verify-email?token={user.VerificationToken}";
            await _emailService.SendVerificationEmailAsync(new VerificationEmailDTO
            {
                To = user.Email,
                UserName = user.Name,
                VerificationLink = verificationLink
            });

            return true;
        }

        public async Task<bool> VerifyEmailAsync(string token)
        {
            var users = await _userRepository.FindAsync(u => u.VerificationToken == token);
            var user = users.FirstOrDefault();
            if (user == null) return false;

            user.IsVerified = true;
            user.VerificationToken = null;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task ForgotPasswordAsync(ForgotPasswordDTO dto)
        {
            var users = await _userRepository.FindAsync(u => u.Email == dto.Email);
            var user = users.FirstOrDefault();
            if (user == null) return;

            user.ResetPasswordToken = Guid.NewGuid().ToString("N");
            user.ResetPasswordTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _userRepository.UpdateAsync(user);

            var resetLink = $"{_configuration["AppUrl"]}/api/auth/reset-password?token={user.ResetPasswordToken}";
            await _emailService.SendResetPasswordEmailAsync(new ResetPasswordEmailDTO
            {
                To = user.Email,
                UserName = user.Name,
                ResetLink = resetLink
            });
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO dto)
        {
            var users = await _userRepository.FindAsync(u =>
                u.ResetPasswordToken == dto.Token &&
                u.ResetPasswordTokenExpiry > DateTime.UtcNow);

            var user = users.FirstOrDefault();
            if (user == null) return false;

            user.PasswordHash = _passwordHashService.Hash(dto.NewPassword);
            user.ResetPasswordToken = null;
            user.ResetPasswordTokenExpiry = null;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            if (!_passwordHashService.Verify(dto.CurrentPassword, user.PasswordHash))
                return false;

            user.PasswordHash = _passwordHashService.Hash(dto.NewPassword);
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
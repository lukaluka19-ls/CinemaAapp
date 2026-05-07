using AutoMapper;
using CinemaApp.Domain.Models; // Dodaj tvoju putanju do entiteta
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        public readonly IAuthService repository;
        public readonly IMapper _mapper;

        public AuthService(IAuthService repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AuthResponseDto>> GetAllAsync()
        {
            var users = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthResponseDto>>(users);
        }
        public async Task<AuthResponseDto> GetByIDAsync(int id)
        {
            var user = await repository.GetByIDAsync(id);
            return _mapper.Map<AuthResponseDto>(user);
        }
        public async Task<RegisterDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<User>(registerDTO);
            var createdUser = await repository.RegisterAsync(registerDTO);
            return _mapper.Map<RegisterDTO>(createdUser);
        }
        public async Task<LoginDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = _mapper.Map<User>(loginDTO);
            var loggedInUser = await repository.LoginAsync(loginDTO);
            return _mapper.Map<LoginDTO>(loggedInUser);
        }
        public async Task<ChangePasswordDTO> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            var user = _mapper.Map<User>(changePasswordDTO);
            var changedPasswordUser = await repository.ChangePasswordAsync(changePasswordDTO);
            return _mapper.Map<ChangePasswordDTO>(changedPasswordUser);
        }
        public async Task<ForgotPasswordDTO> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = _mapper.Map<User>(forgotPasswordDTO);
            var forgotPasswordUser = await repository.ForgotPasswordAsync(forgotPasswordDTO);
            return _mapper.Map<ForgotPasswordDTO>(forgotPasswordUser);
        }
        public async Task<ResetPasswordDTO> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var user = _mapper.Map<User>(resetPasswordDTO);
            var resetPasswordUser = await repository.ResetPasswordAsync(resetPasswordDTO);
            return _mapper.Map<ResetPasswordDTO>(resetPasswordUser);
        }
        public async Task<UserResponseDto> GetCurrentUserAsync(int id)
        {
            var user = await repository.GetCurrentUserAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }
        public async Task<VerifyEmailResponseDto> VerifyEmailAsync(VerifyEmailResponseDto verifyEmailDTO)
        {
            var user = _mapper.Map<User>(verifyEmailDTO);
            var verifiedUser = await repository.VerifyEmailAsync(verifyEmailDTO);
            return _mapper.Map<VerifyEmailResponseDto>(verifiedUser);
        }

    }
}

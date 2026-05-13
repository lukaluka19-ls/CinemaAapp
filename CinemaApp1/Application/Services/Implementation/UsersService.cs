using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Services.Interfaces;
using NPOI.SS.Formula.Functions;

namespace CinemaApp1.Application.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

       public UsersService(IUserRepository usersService, IPasswordHashService passwordHashService, IMapper mapper, IEmailService emailService)
        {
            _userRepository = usersService;
            _passwordHashService = passwordHashService;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<IEnumerable<UserListDTO>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserListDTO>>(user);
        }
        public async Task<UserResponseDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User does not exists");
            return _mapper.Map<UserResponseDTO?>(user);
        }

        public async Task BlockUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User does not exists!");
            user.IsBlocked = true;
            await _userRepository.UpdateAsync(user);

        }
        public async Task UnblockUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User does not exists!");
            user.IsBlocked = false;
            await _userRepository.UpdateAsync(user);

        }
    }
}

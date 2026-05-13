using CinemaApp.Infrastructure.Repositories.Implementations;

namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserListDTO>>GetAllUsersAsync();
        Task<UserResponseDTO?> GetUserById(int id);
        Task BlockUserAsync(int id);
        Task UnblockUserAsync(int id);
    }
}

using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?>GetByEmailOrUsernameAsync(string emailOrUsername);
        Task<User?> GetByUsernameAsync(string email);
        Task UpdatePasswordAsync(int userId, string newPasswordHas);
        Task BlockUserAsync(int userId);
        Task UnblockUserAsync(int userId);

    }
}

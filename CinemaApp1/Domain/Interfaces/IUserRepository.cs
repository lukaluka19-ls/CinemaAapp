using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser?>GetByEmailOrUsernameAsync(string emailOrUsername);
        Task<ApplicationUser?> GetByUsernameAsync(string email);
        Task UpdatePasswordAsync(int userId, string newPasswordHas);
        Task BlockUserAsync(int userId);
        Task UnblockUserAsync(int userId);

    }
}

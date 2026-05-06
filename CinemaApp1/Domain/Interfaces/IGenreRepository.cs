using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IGenreRepository: IGenericRepository<Genre>
    {
        Task<Genre?>GetByNameAsync(string name);
    }
}

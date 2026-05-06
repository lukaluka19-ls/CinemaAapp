using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IScreeningRepository : IGenericRepository<MovieScreening>
    {
        Task<IEnumerable<MovieScreening>> GetUpcomingForNextDaysAsync(int days);
        Task<IEnumerable<MovieScreening>> GetByMovieIdAsync(int movieId);
    }
}

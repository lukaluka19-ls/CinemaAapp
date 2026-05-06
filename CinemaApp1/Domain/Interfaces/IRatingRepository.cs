using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<bool>HasUserRatedTheMovie(int userId, int movieId);
        Task<double> GetAverageRatingForMovie(int movieId);
    }
}

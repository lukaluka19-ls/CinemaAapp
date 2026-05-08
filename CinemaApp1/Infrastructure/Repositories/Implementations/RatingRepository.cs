using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Infrastructure.Repositories.Implementations
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> HasUserRatedTheMovie(int userId, int movieId)
        {
            return await _context.Ratings.AnyAsync(r => r.UserId == userId && r.MovieId == movieId);
        }

        public async Task<double> GetAverageRatingForMovie(int movieId)
        {
            var ratings = await _context.Ratings.Where(r => r.MovieId == movieId).ToListAsync();
            if (ratings.Count == 0) return 0;
            return ratings.Average(r => r.Stars);
        }



    }
}

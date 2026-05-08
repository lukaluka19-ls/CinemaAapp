using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CinemaApp.Infrastructure.Repositories.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        private readonly GenericRepository<Movie> _genericRepository;


        public MovieRepository(AppDbContext context)
        {
            _context = context;
            _genericRepository = new GenericRepository<Movie>(context);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }


        public async Task<IEnumerable<Movie>> GetAllWithGenresAsync()
        {
            return await _context.Movies.Include(m => m.Genre).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenresAndRatingsAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.Ratings)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllWithGenreAndRatingsAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.Ratings)
                .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetAllWithRatingsAsync()
        {
            return await _context.Movies.Include(m => m.Ratings).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Movie entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }

        public Task<Movie> AddAsync(Movie entity)
        {
            return _genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Movie entity)
        {
            await _genericRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Movie>>GetByGenreIdAsync(int genreId)
        {
            return await _context.Movies.Where(m => m.GenreId == genreId).ToListAsync();
        }

        public async Task<double> GetAverageRatingAsync(int movieId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.MovieId == movieId)
                .ToListAsync();

            if (!ratings.Any()) return 0;
            return ratings.Average(r => r.Stars);
        }

        public async Task<bool> AnyAsync(Expression<Func<Movie, bool>> predicate)
        {
            return await _genericRepository.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Movie>> FindAsync(Expression<Func<Movie, bool>> predicate)
        {
            return await _context.Movies.Where(predicate).ToListAsync();
        }
    }
}

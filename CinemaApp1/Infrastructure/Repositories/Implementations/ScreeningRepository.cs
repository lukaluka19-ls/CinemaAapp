using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaApp.Infrastructure.Repositories.Implementations
{
    public class ScreeningRepository : GenericRepository<MovieScreening>, IScreeningRepository
    {
        private readonly AppDbContext _context;

        public ScreeningRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieScreening>> GetUpcomingForNextDaysAsync(int days)
        {
            var now = DateTime.UtcNow;
            var limit = now.AddDays(days);

            return await _context.MovieScreenings
                .Include(s => s.Movie)
                    .ThenInclude(m => m.Genre)
                .Include(s => s.Seats)
                .Where(s => s.DateTime >= now && s.DateTime <= limit)
                .OrderBy(s => s.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieScreening>> GetByMovieIdAsync(int movieId)
        {
            return await _context.MovieScreenings
                .Include(s => s.Movie)
                .Include(s => s.Seats)
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieScreening>> GetFilteredAsync(ScreeningFilterDTO filter)
        {
            var query = _context.MovieScreenings
                .Include(s => s.Movie)
                    .ThenInclude(m => m.Genre)
                .Include(s => s.Seats)
                .Where(s => s.DateTime >= DateTime.UtcNow)
                .AsQueryable();

            if (filter.Date.HasValue)
                query = query.Where(s => s.DateTime.Date == filter.Date.Value.Date);

            if (filter.GenreId.HasValue)
                query = query.Where(s => s.Movie.GenreId == filter.GenreId.Value);

            query = filter.SortBy switch
            {
                "name" => filter.SortOrder == "desc"
                    ? query.OrderByDescending(s => s.Movie.Name)
                    : query.OrderBy(s => s.Movie.Name),
                _ => filter.SortOrder == "desc"
                    ? query.OrderByDescending(s => s.DateTime)
                    : query.OrderBy(s => s.DateTime)
            };

            return await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }
    }
}
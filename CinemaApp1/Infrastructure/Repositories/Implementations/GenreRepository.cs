using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaApp.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> FindAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _context.Genres.Where(predicate).ToListAsync();
        }

        public async Task<Genre> AddAsync(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Genre entity)
        {
            _context.Genres.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _context.Genres.AnyAsync(predicate);
        }

        // specificna metoda samo za Genre
        public async Task<Genre?> GetByNameAsync(string name)
        {
            return await _context.Genres
                .FirstOrDefaultAsync(g => g.Name.ToLower() == name.ToLower());
        }
    }
}
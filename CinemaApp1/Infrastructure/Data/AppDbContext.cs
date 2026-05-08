using Microsoft.EntityFrameworkCore;
using CinemaApp.Domain.Models;

namespace CinemaApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MovieScreening> MovieScreenings { get; set; }
        public DbSet<ReservationSeat> ReservationSeats { get; set; }
        public DbSet<Rating> Ratings { get; set; } // ← ovo
    }
}
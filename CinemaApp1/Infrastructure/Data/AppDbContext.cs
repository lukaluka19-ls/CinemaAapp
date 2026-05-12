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
        public DbSet<Rating> Ratings { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@cinemaapp.com",
                DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                PasswordHash = "100000.tRxqU6dDAmCFYuEku/TZag==.Bb6Z/x+8cOATAmOT6T45bapxqb/ciIXDb0+J71McIjM=",
                Role = (int)UserRole.Admin,
                IsVerified = true,
                IsBlocked = false,
                VerificationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null
            });
            //AUTOINCREMENT VALUES FOR EVERY
            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Genre>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MovieScreening>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Seat>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ReservationSeat>()
                .Property(rs => rs.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rating>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
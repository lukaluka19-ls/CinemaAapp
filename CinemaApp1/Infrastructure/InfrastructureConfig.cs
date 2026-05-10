using CinemaApp.Data;
using CinemaApp.Data.Repositories;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Repositories.Implementations;
using CinemaApp1.Application.Services.Implementation;
using CinemaApp1.Application.Services.Interfaces;
using CinemaApp1.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CinemaApp1.Infrastructure
{
    public static class InfrastructureConfig
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IScreeningRepository, ScreeningRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMoviesService, MovieService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IScreeningService, ScreeningService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
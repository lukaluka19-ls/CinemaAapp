using CinemaApp.BusinessLayer.Validators;
using CinemaApp.Data;
using CinemaApp1.Application.Services.Implementation;
using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaApp1.Infrastructure.Auth
{
    public class JwtService : IJwtService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHashService _passwordHashService;


        public JwtService(AppDbContext dbContext, IConfiguration configuration, IPasswordHashService passwordHashService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _passwordHashService = passwordHashService;

        }

        public async Task<AuthResponseDto?> Authenticate(LoginDTO request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return null;

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !_passwordHashService.Verify(request.Password, user.PasswordHash))
                return null;


            if (!user.IsVerified)
                return null;

            if (user.IsBlocked)
                return null;

            var issuer = _configuration["JwtConfig:Issuer"];
            var audience = _configuration["JwtConfig:Audience"];
            var key = _configuration["JwtConfig:Key"];
            var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityInMinutes");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(tokenValidityMins),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponseDto
            {
                Token = tokenHandler.WriteToken(securityToken),
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }
    }
}
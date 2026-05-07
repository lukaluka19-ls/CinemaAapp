using CinemaApp.Data;
using CinemaApp1.Application.Services.Implementation;
using CinemaApp1.Domain.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

namespace CinemaApp1.Presentation.Middleware
{
    public class JwtService
    {
        private readonly AppDbContext _dbcontext;
        private readonly IConfiguration _configuration;
        public JwtService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _configuration = configuration;
        }
        public async Task<LoginResponseModel> Authenticate(LoginResponseModel request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return null;

            var userAccount = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if userAccount == null || !PasswordHashService.VerifyPassword(request.Password, userAccount.PasswordHash)
                return null;

            var isuer = _configuration["JwtConfiguration:Issuer"];
            var audience = _configuration["JwtConfiguration:Audience"];
            var key = _configuration["JwtConfiguration:Key"];
            var tokenValidityMins = _configuration.GetValue<int>("JwtConfiguration:TokenValidityInMinutes");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userAccount.UserName),
                    new Claim(ClaimTypes.NameIdentifier, userAccount.Id.ToString())
                }),
                Expires = tokenExpiryTimeStamp,
                Issuer = isuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new LoginResponseModel
            {
                Username = userAccount.UserName,
                AccessToken = accessToken,
                EpiresIn = tokenValidityMins
            };
        }
    }
}

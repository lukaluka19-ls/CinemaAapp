using CinemaApp.Data;
using Microsoft.AspNetCore.Identity.Data;

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
    }
}

using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Infrastructure.Repositories.Implementations
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReservationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Reservation>> GetByScreenign(int screeningId)
        {
            return await _appDbContext.Reservations.Where(r => r.ScreeningId == screeningId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByUserASync(int userId)
        {
            return await _appDbContext.Reservations.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<Reservation> GetByConfirmationCodeAsync(string confirmationCode)
        {
            return await _appDbContext.Reservations.FirstOrDefaultAsync(r => r.UniqueCode == confirmationCode);
        }



    }
}

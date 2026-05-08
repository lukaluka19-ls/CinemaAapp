using CinemaApp.Data;
using CinemaApp.Domain.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Infrastructure.Repositories.Implementations
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly AppDbContext _context;

        public SeatRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Seat>> GetAvailableSeatsByScreeningIdAsync(int screeningId)
        {
            return await _context.Seats
                .Where(s => s.ScreeningId == screeningId && !s.IsOccupied)
                .ToListAsync();
        }

        public async Task UpdateSeatsReservedAsync(IEnumerable<int> seatIds, int reservationId)
        {
            var seatsToUpdate = await _context.Seats
                .Where(s => seatIds.Contains(s.Id))
                .ToListAsync();
            foreach (var seat in seatsToUpdate)
            {
                seat.IsOccupied = true;
                // ovde možete dodati logiku za povezivanje sa rezervacijom ako je potrebno
            }
            await _context.SaveChangesAsync();
        }
    }
}

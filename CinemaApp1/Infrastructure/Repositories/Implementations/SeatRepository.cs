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
                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Seat>> GetRangeAsync(IEnumerable<int> seatsId)
        {
            return await _context.Seats
                .Include(x => x.Reservations)
                .Where(s => seatsId.Contains(s.Id))
                .ToListAsync();
        }

        //public Task<bool> ExistsAsync(int seatNumber)
        //{
        //    return _context.Seats.AnyAsync(s => s.SeatNumber == seatNumber);
        //}

        public Task<bool> ExistsAsync(int seatNumber)
        {
            return _context.Seats.AnyAsync(s => s.SeatNumber == seatNumber);        
        }
    }
}

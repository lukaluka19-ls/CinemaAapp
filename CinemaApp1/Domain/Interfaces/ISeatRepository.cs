using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetAvailableSeatsByScreeningIdAsync(int screeningId);
        Task UpdateSeatsReservedAsync(IEnumerable<int> seatId, int reservationId);
    }
}

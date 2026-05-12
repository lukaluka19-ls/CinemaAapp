namespace CinemaApp.Domain.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetAvailableSeatsByScreeningIdAsync(int screeningId);
        Task UpdateSeatsReservedAsync(IEnumerable<int> seatId, int reservationId);
        Task<IEnumerable<Seat>> GetRangeAsync(IEnumerable<int> seatId);
        Task<bool> ExistsAsync(int seatNumbers);
    }
}

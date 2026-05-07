namespace CinemaApp1.Application.Services.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatResponseDTO>> GetSeatAsync();
        Task<SeatResponseDTO> GetSeatByIdAsync(int id);
        Task<SeatCreateDTO> CreateSeatAsync(SeatCreateDTO seatCreateDTO);

    }
}

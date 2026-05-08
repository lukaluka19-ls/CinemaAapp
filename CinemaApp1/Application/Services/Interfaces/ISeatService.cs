public interface ISeatService
{
    Task<IEnumerable<SeatResponseDTO>> GetAllAsync();
    Task<IEnumerable<SeatResponseDTO>> GetAvailableByScreeningIdAsync(int screeningId);
    Task<SeatResponseDTO?> GetByIdAsync(int id);
    Task<SeatResponseDTO> CreateSeatAsync(SeatCreateDTO dto);
}
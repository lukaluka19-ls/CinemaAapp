namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IScreeningService
    {
        Task<IEnumerable<ScreeningResponseDTO>> GetAllScreeningsAsync();
        Task<ScreeningResponseDTO> GetScreeningByIdAsync(int id);
        Task<ScreeningCreateDTO> CreateScreeningAsync(ScreeningCreateDTO screeningCreateDTO);
        Task<ScreeningUpdateDTO> UpdateScreeningAsync(int id, ScreeningUpdateDTO screeningUpdateDTO);
        Task<bool> DeleteScreeningAsync(int id);
        Task<ScreeningListDTO> GetScreeningListAsync();
    }
}

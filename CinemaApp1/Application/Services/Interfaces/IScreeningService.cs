public interface IScreeningService
{
    Task<IEnumerable<ScreeningResponseDTO>> GetAllScreeningsAsync();
    Task<ScreeningResponseDTO> GetScreeningByIdAsync(int id);
    Task<ScreeningCreateDTO> CreateScreeningAsync(ScreeningCreateDTO dto);
    Task<ScreeningUpdateDTO> UpdateScreeningAsync(int id, ScreeningUpdateDTO dto);
    Task<bool> DeleteScreeningAsync(int id);
    Task<IEnumerable<ScreeningListDTO>> GetScreeningListAsync(ScreeningFilterDTO filter);
}
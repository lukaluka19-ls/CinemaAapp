public interface IScreeningService
{
    Task<IEnumerable<ScreeningResponseDTO>> GetAllScreeningsAsync();
    Task<ScreeningResponseDTO> GetScreeningByIdAsync(int id);
    Task<ScreeningResponseDTO> CreateScreeningAsync(ScreeningCreateDTO dto);
    Task<ScreeningUpdateDTO> UpdateScreeningAsync(int id, ScreeningUpdateDTO dto);
    Task<bool> DeleteScreeningAsync(int id);
    Task<IEnumerable<ScreeningListDTO>> GetScreeningListAsync(ScreeningFilterDTO filter);
    //Task<ScreeningResponseDTO> CreateScreeningAsync(ScreeningCreateDTO dto);
}
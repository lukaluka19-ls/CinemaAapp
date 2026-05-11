public interface IGenreService
{
    Task<IEnumerable<GenreResponseDTO>> GetAllAsync();
    Task<GenreResponseDTO?> GetByIdAsync(int id);
    Task<GenreResponseDTO> CreateAsync(GenreCreateDTO dto); //da dobijemid nazad
    Task<bool> UpdateAsync(int id, GenreUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}
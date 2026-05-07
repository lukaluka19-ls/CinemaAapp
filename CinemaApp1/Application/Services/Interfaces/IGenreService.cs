namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDTO>> GetAllAsync();
        Task<GenreResponseDTO> GetByIDAsync(int id);
        Task<GenreCreateDTO> CreateAsync(GenreCreateDTO dto);
        Task<bool>UpdateAsync(int id,GenreUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

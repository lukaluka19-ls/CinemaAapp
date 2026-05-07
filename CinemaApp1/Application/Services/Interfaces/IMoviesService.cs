namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieResponseDTO>> GetAllAsync();
        Task<MovieResponseDTO> GetByIDAsync(int id);
        Task<MovieCreateDTO> CreateAsync(MovieCreateDTO dto);
        Task<MovieUpdateDTO> UpdateAsync(int id, MovieUpdateDTO dto);
        
    }
}

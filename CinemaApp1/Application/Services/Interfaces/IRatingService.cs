namespace CinemaApp1.Application.Services.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingResponseDTO>> GetAllAsync();
        Task<RatingResponseDTO> GetByIDAsync(int id);
        Task<RatingCreateDTO> CreateAsync(RatingCreateDTO dto);

    }
}

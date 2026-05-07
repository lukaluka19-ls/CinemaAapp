using CinemaApp1.Application.DTOs.Common;
//using CinemaApp1.Application.DTOs.Consumer;
//using CinemaApp1.Application.DTOs.Genre;
//using CinemaApp1.Application.DTOs.Movie;

public interface IAdminService
{
    Task<PagedResponseDTO<ConsumerListDTO>> GetAllConsumersAsync(int page, int pageSize, string? search, char? firstLetter);
    Task<ConsumerResponseDTO?> GetConsumerByIdAsync(int id);
    Task BlockConsumerAsync(int id);
    Task UnblockConsumerAsync(int id);
    Task ResetConsumerPasswordAsync(int id);

    Task<PagedResponseDTO<GenreResponseDTO>> GetAllGenresAsync(int page, int pageSize, string? search, char? firstLetter);
    Task<GenreResponseDTO?> GetGenreByIdAsync(int id);
    Task<GenreResponseDTO> CreateGenreAsync(GenreCreateDTO dto);
    Task UpdateGenreAsync(int id, GenreUpdateDTO dto);
    Task DeleteGenreAsync(int id);

    Task<PagedResponseDTO<MovieResponseDTO>> GetAllMoviesAsync(int page, int pageSize, string? search, char? firstLetter);
    Task<MovieResponseDTO?> GetMovieByIdAsync(int id);
    Task<MovieResponseDTO> CreateMovieAsync(MovieCreateDTO dto);
    Task UpdateMovieAsync(int id, MovieUpdateDTO dto);
    Task DeleteMovieAsync(int id);

    Task<PagedResponseDTO<ScreeningListDTO>> GetAllScreeningsAsync(int page, int pageSize);
    Task<ScreeningResponseDTO?> GetScreeningByIdAsync(int id);
    Task<ScreeningResponseDTO> CreateScreeningAsync(ScreeningCreateDTO dto);
    Task UpdateScreeningAsync(int id, ScreeningUpdateDTO dto);
    Task DeleteScreeningAsync(int id);
}
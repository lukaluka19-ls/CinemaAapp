using CinemaApp.Domain.Interfaces;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<IEnumerable<Movie>> GetAllWithGenresAsync();
    Task<IEnumerable<Movie>> GetAllWithGenreAndRatingsAsync();
    Task<IEnumerable<Movie>> GetAllWithRatingsAsync();
    Task<IEnumerable<Movie>> GetByGenreIdAsync(int genreId);
    Task<double> GetAverageRatingAsync(int movieId);
}
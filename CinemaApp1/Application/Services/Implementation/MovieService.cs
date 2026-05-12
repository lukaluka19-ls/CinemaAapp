using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class MovieService : IMoviesService
    {
        public readonly IMovieRepository repository;
        public readonly IMapper _mapper;

        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task <IEnumerable<MovieResponseDTO>> GetAllAsync()
        {
            var movies = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieResponseDTO>>(movies);
        }
        
        public async Task<MovieResponseDTO> GetByIDAsync(int id)
        {
            var movie = await repository.GetByIdAsync(id);
            return _mapper.Map<MovieResponseDTO>(movie);
        }
        public async Task<MovieResponseDTO> CreateAsync(MovieCreateDTO dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            var createdMovie = await repository.AddAsync(movie);
            if (createdMovie != null)
                return _mapper.Map<MovieResponseDTO>(createdMovie);
            else
                throw new Exception("Already Exists");
        }
        public async Task<MovieUpdateDTO> UpdateAsync(int id, MovieUpdateDTO dto)
        {
            var movie = await repository.GetByIdAsync(id);
            if (movie == null)
                return null;
            _mapper.Map(dto, movie);
            await repository.UpdateAsync(movie);
            return _mapper.Map<MovieUpdateDTO>(movie);
        }
    }
}

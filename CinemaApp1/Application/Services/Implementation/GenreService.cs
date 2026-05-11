using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CinemaApp1.Application.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreResponseDTO>> GetAllAsync()
        {
            var genres = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreResponseDTO>>(genres);
        }

        public async Task<GenreResponseDTO> GetByIdAsync(int id)
        {
            var genre = await repository.GetByIdAsync(id);
            return _mapper.Map<GenreResponseDTO>(genre);
        }
        public async Task<GenreCreateDTO> CreateAsync(GenreCreateDTO dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            await repository.AddAsync(genre);
            return _mapper.Map<GenreResponseDTO>(genre);
        }
        public async Task<bool> UpdateAsync(int id, GenreUpdateDTO dto)
        {
            var genre = await repository.GetByIdAsync(id);
            if (genre == null)
                return false;
            _mapper.Map(dto, genre);
            await repository.UpdateAsync(genre);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await repository.GetByIdAsync(id);
            if (genre == null)
                return false;
            await repository.DeleteAsync(genre);
            return true;

        }
    }
}

using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Mapping;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingResponseDTO>> GetAllAsync()
        {
            var ratings = await _ratingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RatingResponseDTO>>(ratings);
        }

        public async Task<RatingResponseDTO> GetByIDAsync(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);
            return _mapper.Map<RatingResponseDTO>(rating);
        }

        public async Task<RatingResponseDTO> CreateAsync(RatingCreateDTO dto)
        {
            var rating = _mapper.Map<Rating>(dto);
            var createdRating = await _ratingRepository.AddAsync(rating);
            return _mapper.Map<RatingResponseDTO>(createdRating);
        }

        Task<RatingCreateDTO> IRatingService.CreateAsync(RatingCreateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
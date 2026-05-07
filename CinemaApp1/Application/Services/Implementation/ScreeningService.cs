using AutoMapper;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class ScreeningService : IScreeningService
    {
        public readonly IScreeningService _screeningRepository;
        public readonly IMapper _mapper;

        public ScreeningService(IScreeningService screeningRepository, IMapper mapper)
        {
            _screeningRepository = screeningRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScreeningResponseDTO>> GetAllScreeningsAsync()
        {
            var screenings = await _screeningRepository.GetAllScreeningsAsync();
            return _mapper.Map<IEnumerable<ScreeningResponseDTO>>(screenings);
        }
        public async Task<ScreeningResponseDTO> GetScreeningByIdAsync(int id)
        {
            var screening = await _screeningRepository.GetScreeningByIdAsync(id);
            return _mapper.Map<ScreeningResponseDTO>(screening);
        }
        public async Task<ScreeningCreateDTO> CreateScreeningAsync(ScreeningCreateDTO screeningCreateDTO)
        {
            var screening = _mapper.Map<MovieScreening>(screeningCreateDTO);
            var createdScreening = await _screeningRepository.CreateScreeningAsync(screeningCreateDTO);
            return _mapper.Map<ScreeningCreateDTO>(createdScreening);
        }
        public async Task<bool> DeleteScreeningAsync(int id)
        {
            return await _screeningRepository.DeleteScreeningAsync(id);
        }
        public async Task<ScreeningUpdateDTO> UpdateScreeningAsync(int id, ScreeningUpdateDTO screeningUpdateDTO)
        {
            var screening = _mapper.Map<MovieScreening>(screeningUpdateDTO);
            var updatedScreening = await _screeningRepository.UpdateScreeningAsync(id, screeningUpdateDTO);
            return _mapper.Map<ScreeningUpdateDTO>(updatedScreening);
        }
        public async Task<ScreeningListDTO> GetScreeningListAsync()
        {
            var screenings = await _screeningRepository.GetScreeningListAsync();
            return _mapper.Map<ScreeningListDTO>(screenings);


        }
    }
}

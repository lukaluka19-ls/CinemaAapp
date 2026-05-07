using AutoMapper;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class SeatService : ISeatService
    {
        public readonly ISeatService _serviceOfWork;
        public readonly IMapper _mapper;

        public SeatService(ISeatService unitOfWork, IMapper mapper)
        {
            _serviceOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SeatResponseDTO>> GetSeatAsync()
        {
            var seat = await _serviceOfWork.GetSeatAsync();
            return _mapper.Map<IEnumerable<SeatResponseDTO>>(seat);
        }
        public async Task<SeatResponseDTO> GetSeatByIdAsync(int id)
        {
            var seat = await _serviceOfWork.GetSeatByIdAsync(id);
            return _mapper.Map<SeatResponseDTO>(seat);
        }

        public async Task<SeatCreateDTO> CreateSeatAsync(SeatCreateDTO seatCreateDTO)
        {
            var seat = _mapper.Map<Seat>(seatCreateDTO);
            var createdSeat = await _serviceOfWork.CreateSeatAsync(seatCreateDTO);
            return _mapper.Map<SeatCreateDTO>(createdSeat);

        }
    }
}

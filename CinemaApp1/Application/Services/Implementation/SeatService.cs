using AutoMapper;
using CinemaApp.Domain.Interfaces;
using Raven.Client.Exceptions;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public SeatService(ISeatRepository seatRepository, IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SeatResponseDTO>> GetAllAsync()
    {
        var seats = await _seatRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SeatResponseDTO>>(seats);
    }

    public async Task<IEnumerable<SeatResponseDTO>> GetAvailableByScreeningIdAsync(int screeningId)
    {
        var seats = await _seatRepository.GetAvailableSeatsByScreeningIdAsync(screeningId);
        return _mapper.Map<IEnumerable<SeatResponseDTO>>(seats);
    }

    public async Task<SeatResponseDTO?> GetByIdAsync(int id)
    {
        var seat = await _seatRepository.GetByIdAsync(id);
        if (seat == null) return null;
        return _mapper.Map<SeatResponseDTO>(seat);
    }

    public async Task<SeatResponseDTO> CreateSeatAsync(SeatCreateDTO dto)
    {
        var exists = await _seatRepository.ExistsAsync(dto.SeatNumber);
        if (exists) 
            throw new Exception("This seat already exists.");

        var seat = _mapper.Map<Seat>(dto);
        await _seatRepository.AddAsync(seat);
        return _mapper.Map<SeatResponseDTO>(seat);
    }
}
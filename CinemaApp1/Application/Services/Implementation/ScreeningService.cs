    using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

public class ScreeningService : IScreeningService
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;

    public ScreeningService(IScreeningRepository screeningRepository, IMapper mapper)
    {
        _screeningRepository = screeningRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ScreeningResponseDTO>> GetAllScreeningsAsync()
    {
        var screenings = await _screeningRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ScreeningResponseDTO>>(screenings);
    }

    public async Task<ScreeningResponseDTO> GetScreeningByIdAsync(int id)
    {
        var screening = await _screeningRepository.GetByIdAsync(id);
        if (screening == null) return null;
        return _mapper.Map<ScreeningResponseDTO>(screening);
    }

    public async Task<ScreeningResponseDTO> CreateScreeningAsync(ScreeningCreateDTO dto)
    {
        var screening = _mapper.Map<MovieScreening>(dto);
        var created = await _screeningRepository.AddAsync(screening);

        //var screening = await screeningRepository.GetByIdAsync(dto.ScreeningId);
        //foreach (var s in screening)
        //{
        //    if (s.)
        //}

         return _mapper.Map<ScreeningResponseDTO>(created);
    }

    public async Task<ScreeningUpdateDTO> UpdateScreeningAsync(int id, ScreeningUpdateDTO dto)
    {
        var screening = await _screeningRepository.GetByIdAsync(id);
        if (screening == null) return null;
        _mapper.Map(dto, screening);
        await _screeningRepository.UpdateAsync(screening);
        return _mapper.Map<ScreeningUpdateDTO>(screening);
    }

    public async Task<bool> DeleteScreeningAsync(int id)
    {
        var screening = await _screeningRepository.GetByIdAsync(id);
        if (screening == null) return false;
        await _screeningRepository.DeleteAsync(screening);
        return true;
    }

    public async Task<IEnumerable<ScreeningListDTO>> GetScreeningListAsync(ScreeningFilterDTO filter)
    {
        var screenings = await _screeningRepository.GetFilteredAsync(filter);
        return _mapper.Map<IEnumerable<ScreeningListDTO>>(screenings);
    }
}
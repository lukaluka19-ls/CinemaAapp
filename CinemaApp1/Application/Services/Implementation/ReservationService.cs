using AutoMapper;
using CinemaApp.Domain.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class ReservationService
    {
        public readonly IReservationRepository repository;
        public readonly IMapper _mapper;

        public async Task<IEnumerable<ReservationResponseDTO>> GetAllAsync()
        {
            var genres = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationResponseDTO>>(genres);
        }

        public async Task<ReservationResponseDTO> GetByIDAsync(int id)
        {
            var genre = await repository.GetByIdAsync(id);
            return _mapper.Map<ReservationResponseDTO>(genre);
        }
        public async Task<CreateReservationDTO> CreateAsync(CreateReservationDTO dto)
        {
            var genre = _mapper.Map<Reservation>(dto);
            var createdGenre = await repository.AddAsync(genre);
            return _mapper.Map<CreateReservationDTO>(createdGenre);
        }
        public async Task<ReservationDetailDTO> GetDetailAsync(int id)
        {
            var reservation = await repository.GetByIdAsync(id);
            return _mapper.Map<ReservationDetailDTO>(reservation);
        }

        public async Task<ReservationListDTO> GetListAsync()
        {
            var reservations = await repository.GetAllAsync();
            return _mapper.Map<ReservationListDTO>(reservations);

        }
    }
}

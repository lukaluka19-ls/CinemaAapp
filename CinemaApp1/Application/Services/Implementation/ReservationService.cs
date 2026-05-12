using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Repositories.Implementations;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class ReservationService : IReservationService
    {
        public readonly IReservationRepository repository;
        public readonly IMapper _mapper;

        public ReservationService(IReservationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationResponseDTO>> GetAllAsync()
        {
            var reservations = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationResponseDTO>>(reservations);
        }
        public async Task<ReservationResponseDTO> GetByIDAsync(int id)
        {
            var reservation = await repository.GetByIdAsync(id);
            return _mapper.Map<ReservationResponseDTO>(reservation);
        }
        public async Task<ReservationResponseDTO> CreateAsync(CreateReservationDTO dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            reservation.UniqueCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            reservation.CreatedAt = DateTime.UtcNow;
            reservation.IsCanceled = false;

            var createdReservation = await repository.AddAsync(reservation);
            return _mapper.Map<ReservationResponseDTO>(createdReservation);
        }

        public async Task<ReservationDetailDTO> GetDetailAsync(int id)
        {
            var reservation = await repository.GetByIdAsync(id);
            if (reservation == null) return null;
            return _mapper.Map<ReservationDetailDTO>(reservation);
        }

        public async Task<IEnumerable<ReservationListDTO>> GetListAsync(int userId)
        {
            var reservations = await repository.GetByIdAsync(userId);
            return _mapper.Map<IEnumerable<ReservationListDTO>>(reservations);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await repository.GetByIdAsync(id);
            if (reservation == null) return false;
            await repository.DeleteAsync(reservation);
            return true;
        }
    }
}

using AutoMapper;
using CinemaApp.Domain.Interfaces;
using CinemaApp1.Application.Services.Interfaces;

namespace CinemaApp1.Application.Services.Implementation
{
    public class ReservationService(
        IReservationRepository repository, 
        IMapper mapper,
        ISeatRepository seatsRepository,
        IScreeningRepository screeningRepository,
        IUserContext userContext) : IReservationService
    {
        private readonly IReservationRepository repository = repository;
        private readonly ISeatRepository seatsRepository = seatsRepository;
        private readonly IScreeningRepository screeningRepository = screeningRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserContext _userContext = userContext;

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
            //get seats by ids
            //existing check

            var screening = await screeningRepository.GetByIdAsync(dto.ScreeningId);
            if (screening == null)
            {
                throw new Exception("Screening id not foudnd");
            }

            var seats = await seatsRepository.GetRangeAsync(dto.SeatIds);

            var nonExistingSeats = dto.SeatIds.Except(seats.Select(x => x.Id)).ToList();
            if(nonExistingSeats.Count != 0)
            {
                throw new Exception($"Seats with ids {string.Join(", ", nonExistingSeats)} is ocupied");
            }

            foreach (var seat in seats)
            {
                if (seat.IsOccupiedCheck())
                {
                    throw new Exception($"Seat {seat.Id} is ocupied");
                }
                if (seat.ScreeningId != dto.ScreeningId)
                {
                    throw new Exception($"Seat {seat.Id} does not belong to this screening session");
                }
            }

            var reservation = _mapper.Map<Reservation>(dto);
            reservation.UniqueCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            reservation.CreatedAt = DateTime.UtcNow;
            reservation.IsCanceled = false;
            reservation.Seats = [.. seats];
            reservation.UserId = _userContext.UserId;

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

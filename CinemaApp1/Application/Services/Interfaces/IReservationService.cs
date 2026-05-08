public interface IReservationService
{
    Task<IEnumerable<ReservationResponseDTO>> GetAllAsync();
    Task<ReservationResponseDTO> GetByIDAsync(int id);
    Task<CreateReservationDTO> CreateAsync(CreateReservationDTO dto);
    Task<ReservationDetailDTO> GetDetailAsync(int id);
    Task<IEnumerable<ReservationListDTO>> GetListAsync(int userId);
}
namespace CinemaApp1.Application.DTOs.Reservation
{
    public class ReservationListDTO
    {
        public IEnumerable<ReservationResposneDTO> Current { get; set; } = [];
        public IEnumerable<ReservationResposneDTO> Past { get; set; } = [];
    }
}

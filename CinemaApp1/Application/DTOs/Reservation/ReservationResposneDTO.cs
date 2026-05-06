using CinemaApp1.Application.DTOs.Screening;
using CinemaApp1.Application.DTOs.Seat;

namespace CinemaApp1.Application.DTOs.Reservation
{
    public class ReservationResposneDTO
    {
        public int Id { get; set; } 
        public string ConfirmationCode { get; set; }=string.Empty;
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isPast { get; set; }
        public SeatResponseDto? Seat { get; set; }
        public ScreeningResponseDTO? Screening { get; set; }
        public int? UserRating { get; set; } ///0(null) ako nije ocenjen

    }
}

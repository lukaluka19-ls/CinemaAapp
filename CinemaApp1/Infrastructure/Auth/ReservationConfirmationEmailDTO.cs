namespace CinemaApp1.Application.DTOs.Email
{
    public class ReservationConfirmationEmailDTO
    {
        public string To { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string MovieName { get; set; } = null!;
        public DateTime ScreeningDateTime { get; set; }
        public string UniqueCode { get; set; } = null!;
        public List<int> SeatNumbers { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}
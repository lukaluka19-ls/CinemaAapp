using System.ComponentModel.DataAnnotations;

public class ScreeningUpdateDTO
{
    public DateTime? DateTime { get; set; }
    [Range(0.01, 10000)]
    public decimal? TicketPrice { get; set; }
    [Range(1, 500)]
    public int? TotalSeats { get; set; }
}
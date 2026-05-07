using System.ComponentModel.DataAnnotations;

public class ScreeningCreateDTO
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    [Range(0.01, 10000)]
    public decimal TicketPrice { get; set; }
    [Required]
    [Range(1, 500)]
    public int TotalSeats { get; set; }
}
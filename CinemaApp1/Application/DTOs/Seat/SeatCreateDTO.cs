using System.ComponentModel.DataAnnotations;

public class SeatCreateDTO
{
    [Required]
    public int ScreeningId { get; set; }
    [Required]
    [Range(1, 500)]
    public int SeatNumber { get; set; }
}
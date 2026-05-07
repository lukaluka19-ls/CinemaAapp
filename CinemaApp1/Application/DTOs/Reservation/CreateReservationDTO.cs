using System.ComponentModel.DataAnnotations;

public class CreateReservationDTO
{
    [Required]
    public int ScreeningId { get; set; }
    [Required]
    [MinLength(1)]
    public List<int> SeatIds { get; set; } = new();
    [EmailAddress]
    public string? GuestEmail { get; set; }  // null ako je auth user
}
using System.ComponentModel.DataAnnotations;

public class RatingCreateDTO
{
    [Required]
    [Range(1, 5)]
    public int Stars { get; set; }
    [Required]
    public int ReservationId { get; set; }
}
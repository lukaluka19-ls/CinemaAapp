public class Rating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ReservationId { get; set; }
    public int Stars { get; set; }
    public DateTime CreatedAt { get; set; }

    // navigaciona svojstva
    public User User { get; set; } = null!;
    public Reservation Reservation { get; set; } = null!;
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}
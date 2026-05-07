public class RatingResponseDTO
{
    public int Id { get; set; }
    public int Stars { get; set; }
    public string MovieName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
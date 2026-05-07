public class SeatResponseDTO
{
    public int Id { get; set; }
    public int SeatNumber { get; set; }
    public string Status { get; set; } = null!; // "Available", "Occupied", "Selected"
}
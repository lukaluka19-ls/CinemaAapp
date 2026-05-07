public class UserResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsVerified { get; set; }
}
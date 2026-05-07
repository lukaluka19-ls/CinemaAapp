public class UserListDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsBlocked { get; set; }
    public bool IsVerified { get; set; }
}
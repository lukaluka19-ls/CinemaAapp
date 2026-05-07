using System.ComponentModel.DataAnnotations;

public class RegisterDTO
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = null!;
}
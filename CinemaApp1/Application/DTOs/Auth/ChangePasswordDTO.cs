using System.ComponentModel.DataAnnotations;

public class ChangePasswordDTO
{
    [Required]
    public string CurrentPassword { get; set; } = null!;
    [Required]
    [MinLength(8)]
    public string NewPassword { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

public class ResetPasswordDTO
{
    [Required]
    public string Token { get; set; } = null!;
    [Required]
    [MinLength(8)]
    public string NewPassword { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

public class BlockUserDTO
{
    [Required]
    public bool IsBlocked { get; set; }
}
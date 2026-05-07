using System.ComponentModel.DataAnnotations;

public class BlockConsumerDTO
{
    [Required]
    public bool IsBlocked { get; set; }
}
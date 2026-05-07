public class ScreeningFilterDTO
{
    public DateTime? Date { get; set; }
    public int? GenreId { get; set; }
    public string? SortBy { get; set; }
    public string? SortOrder { get; set; } 
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
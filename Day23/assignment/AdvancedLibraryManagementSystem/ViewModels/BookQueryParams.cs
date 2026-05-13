namespace AdvancedLibraryManagementSystem.ViewModels;

public class BookQueryParams
{
    public string? Search { get; set; }
    public int? AuthorId { get; set; }
    public int? GenreId { get; set; }
    public string SortBy { get; set; } = "title_asc";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}

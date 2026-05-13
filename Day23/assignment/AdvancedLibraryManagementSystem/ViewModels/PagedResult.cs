namespace AdvancedLibraryManagementSystem.ViewModels;

public record PagedResult<T>(IReadOnlyCollection<T> Items, int TotalCount, int CurrentPage, int PageSize)
{
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}

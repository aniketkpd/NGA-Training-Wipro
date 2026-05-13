using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.ViewModels;

namespace AdvancedLibraryManagementSystem.Repositories.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<PagedResult<Book>> GetPagedBooksAsync(BookQueryParams queryParams);
    Task<Book?> GetBookDetailsAsync(int id);
}

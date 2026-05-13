using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories.Interfaces;
using AdvancedLibraryManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdvancedLibraryManagementSystem.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PagedResult<Book>> GetPagedBooksAsync(BookQueryParams queryParams)
    {
        var query = _context.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryParams.Search))
        {
            query = query.Where(b =>
                b.Title.Contains(queryParams.Search) ||
                (b.Author != null && b.Author.Name.Contains(queryParams.Search)));
        }

        if (queryParams.AuthorId.HasValue)
        {
            query = query.Where(b => b.AuthorId == queryParams.AuthorId.Value);
        }

        if (queryParams.GenreId.HasValue)
        {
            query = query.Where(b => b.BookGenres.Any(bg => bg.GenreId == queryParams.GenreId.Value));
        }

        query = queryParams.SortBy switch
        {
            "year_desc" => query.OrderByDescending(b => b.PublishedYear),
            "year_asc" => query.OrderBy(b => b.PublishedYear),
            "title_desc" => query.OrderByDescending(b => b.Title),
            _ => query.OrderBy(b => b.Title)
        };

        var totalCount = await query.CountAsync();
        var pageSize = Math.Clamp(queryParams.PageSize, 1, 50);
        var page = Math.Max(queryParams.Page, 1);

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Book>(items, totalCount, page, pageSize);
    }

    public async Task<Book?> GetBookDetailsAsync(int id)
    {
        return await _context.Books
            .Include(b => b.Author)
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}

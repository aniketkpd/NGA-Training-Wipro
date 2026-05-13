# Database First Notes

This folder demonstrates the Database First part of the assignment. In a real existing database, the models here would be generated from tables that already exist for `Books`, `Authors`, `Genres`, and the `BookGenres` join table.

Reverse engineering command:

```powershell
dotnet ef dbcontext scaffold "Data Source=existing-library.db" Microsoft.EntityFrameworkCore.Sqlite --context ExistingLibraryContext --context-dir DatabaseFirst --output-dir DatabaseFirst --force
```

The generated classes are marked `partial`. Put custom code in separate partial files, such as `ExistingAuthor.Custom.cs`, so regeneration does not overwrite your changes.

CRUD with generated models follows the same EF Core pattern:

```csharp
var author = new ExistingAuthor { Name = "Mary Shelley", Bio = "English novelist" };
context.Authors.Add(author);
await context.SaveChangesAsync();

var books = await context.Books
    .Include(book => book.Author)
    .Include(book => book.Genres)
    .AsSplitQuery()
    .ToListAsync();
```

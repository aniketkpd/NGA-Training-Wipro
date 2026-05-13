# Advanced Library Management System

This project completes the assignment requirements using:
- ASP.NET Core MVC
- Entity Framework Core (SQL Server)
- Repository Pattern (generic + specific repositories)
- AJAX-based async CRUD operations
- Query optimization (filtering, sorting, pagination, eager loading)
- Error handling for server and client interactions

## Assignment Coverage

1. Repository Pattern with EF Core
   - `Repositories/Interfaces/IGenericRepository.cs`
   - `Repositories/GenericRepository.cs`
   - Specific repositories:
     - `BookRepository`
     - `AuthorRepository`
     - `GenreRepository`

2. CRUD + Relationships + Async operations
   - Entities in `Models/`:
     - `Book` (many-to-one with `Author`)
     - `Genre` + `BookGenre` (many-to-many with `Book`)
   - Async CRUD endpoints in `Controllers/LibraryController.cs`

3. AJAX integration with MVC
   - Main UI: `Views/Library/Index.cshtml`
   - AJAX logic: `wwwroot/js/library.js`
   - Supports no-page-reload create, update, delete, fetch.

4. Advanced optimization + robust handling
   - Eager loading with `Include/ThenInclude`
   - Filtering/sorting/pagination in `BookRepository.GetPagedBooksAsync`
   - Structured error responses in controller + UI alerts in JavaScript

## Run in Visual Studio

1. Open `AdvancedLibraryManagementSystem.csproj` in Visual Studio.
2. Update connection string in `appsettings.json`:
   - Current default:
     - `Server=localhost;Database=AdvancedLibraryDb;Trusted_Connection=True;TrustServerCertificate=True;`
   - Example for SQL Express:
     - `Server=.\\SQLEXPRESS;Database=AdvancedLibraryDb;Trusted_Connection=True;TrustServerCertificate=True;`
3. Apply migration:
   - Package Manager Console:
     - `Update-Database`
   - Or CLI:
     - `dotnet ef database update`
4. Run the project and open `/Library`.

## Run with SSMS

1. Open SSMS and connect to your SQL Server instance.
2. Open and run:
   - `Database/InitialCreate.sql`
3. Verify database `AdvancedLibraryDb` and tables:
   - `Authors`
   - `Books`
   - `Genres`
   - `BookGenres`
   - `__EFMigrationsHistory`
4. Start the MVC app from Visual Studio.

## Notes

- The migration is already added in `Migrations/`.
- If database update fails, ensure SQL Server service is running and the instance name in `appsettings.json` is correct for your machine.

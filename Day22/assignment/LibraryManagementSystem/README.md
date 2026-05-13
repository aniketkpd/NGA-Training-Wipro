# Library Management System - EF Core Assignment

ASP.NET Core Web API implementation for the Wipro NGA .NET Cohort daily coding assignment.

## What is included

- Code First EF Core project with `Author`, `Book`, `Genre`, and `BookGenre` entities.
- One-to-many relationship: one `Author` has many `Books`.
- Many-to-many relationship: many `Books` can have many `Genres`.
- Fluent API configuration in `Data/LibraryContext.cs`.
- CRUD endpoints for books, authors, and genres.
- EF Core migration files in `Migrations/`.
- Database First demonstration in `DatabaseFirst/`, including generated-style models, context, schema script, scaffold command, and CRUD controllers.
- Advanced query endpoint that retrieves books with authors and genres using `Include`, `ThenInclude`, `AsNoTracking`, and `AsSplitQuery`.

## Run

```powershell
cd LibraryManagementSystem
$env:APPDATA="$PWD\.appdata"
$env:NUGET_PACKAGES="$PWD\..\.nuget\packages"
dotnet restore --configfile NuGet.Config
dotnet run
```

The Code First database is created and migrated automatically from `library.db` when the API starts.

## Main endpoints

- `GET /api/authors`
- `POST /api/authors`
- `PUT /api/authors/{id}`
- `DELETE /api/authors/{id}`
- `GET /api/genres`
- `POST /api/genres`
- `PUT /api/genres/{id}`
- `DELETE /api/genres/{id}`
- `GET /api/books`
- `POST /api/books`
- `PUT /api/books/{id}`
- `DELETE /api/books/{id}`
- `GET /api/books/with-author-and-genres`

Database First demonstration endpoints:

- `GET /api/database-first/authors`
- `POST /api/database-first/authors`
- `PUT /api/database-first/authors/{id}`
- `DELETE /api/database-first/authors/{id}`
- `GET /api/database-first/books`
- `POST /api/database-first/books`
- `PUT /api/database-first/books/{id}`
- `DELETE /api/database-first/books/{id}`

## PDF requirement mapping

User Story 1: Code First CRUD

- Entities: `Models/Author.cs`, `Models/Book.cs`
- Relationship: `Data/LibraryContext.cs`
- CRUD: `Controllers/BooksController.cs`

User Story 2: Advanced Code First and migrations

- Genre entity: `Models/Genre.cs`
- Many-to-many: `Models/BookGenre.cs`, `Data/LibraryContext.cs`
- Migration: `Migrations/20260512000000_InitialLibrarySchema.cs`
- Genre CRUD: `Controllers/GenresController.cs`

User Story 3: Database First

- Existing schema: `DatabaseFirst/existing-library-schema.sql`
- Reverse-engineered-style models/context: `DatabaseFirst/`
- Scaffold command and model modification notes: `DatabaseFirst/README.md`
- CRUD using generated models: `Controllers/DatabaseFirstAuthorsController.cs`, `Controllers/DatabaseFirstBooksController.cs`

User Story 4: Advanced querying and performance

- Query: `GET /api/books/with-author-and-genres`
- Uses no-tracking reads and split queries for efficient retrieval of related data.

## Example request bodies

Create author:

```json
{
  "name": "Jane Austen",
  "bio": "English novelist"
}
```

Create genre:

```json
{
  "name": "Classic"
}
```

Create book:

```json
{
  "title": "Pride and Prejudice",
  "authorId": 1,
  "genreIds": [1]
}
```

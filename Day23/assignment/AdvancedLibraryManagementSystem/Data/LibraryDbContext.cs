using AdvancedLibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedLibraryManagementSystem.Data;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<BookGenre> BookGenres => Set<BookGenre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });

        modelBuilder.Entity<BookGenre>()
            .HasOne(bg => bg.Book)
            .WithMany(b => b.BookGenres)
            .HasForeignKey(bg => bg.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookGenre>()
            .HasOne(bg => bg.Genre)
            .WithMany(g => g.BookGenres)
            .HasForeignKey(bg => bg.GenreId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Author>()
            .HasIndex(a => a.Name)
            .IsUnique();

        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.Name)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Title);

        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "George Orwell", Bio = "English novelist and essayist." },
            new Author { Id = 2, Name = "J. K. Rowling", Bio = "British author." }
        );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Dystopian" },
            new Genre { Id = 2, Name = "Fantasy" },
            new Genre { Id = 3, Name = "Classic" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "1984", Isbn = "9780451524935", PublishedYear = 1949, AuthorId = 1 },
            new Book { Id = 2, Title = "Harry Potter and the Philosopher's Stone", Isbn = "9780747532699", PublishedYear = 1997, AuthorId = 2 }
        );

        modelBuilder.Entity<BookGenre>().HasData(
            new BookGenre { BookId = 1, GenreId = 1 },
            new BookGenre { BookId = 1, GenreId = 3 },
            new BookGenre { BookId = 2, GenreId = 2 }
        );
    }
}

using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<BookGenre> BookGenres => Set<BookGenre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(author => author.AuthorId);
            entity.Property(author => author.Name).IsRequired().HasMaxLength(150);
            entity.Property(author => author.Bio).HasMaxLength(1000);
            entity.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(book => book.BookId);
            entity.Property(book => book.Title).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(genre => genre.GenreId);
            entity.Property(genre => genre.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(genre => genre.Name).IsUnique();
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.HasKey(bookGenre => new { bookGenre.BookId, bookGenre.GenreId });
            entity.HasOne(bookGenre => bookGenre.Book)
                .WithMany(book => book.BookGenres)
                .HasForeignKey(bookGenre => bookGenre.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(bookGenre => bookGenre.Genre)
                .WithMany(genre => genre.BookGenres)
                .HasForeignKey(bookGenre => bookGenre.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

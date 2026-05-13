using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DatabaseFirst;

public partial class ExistingLibraryContext(DbContextOptions<ExistingLibraryContext> options) : DbContext(options)
{
    public virtual DbSet<ExistingAuthor> Authors { get; set; }

    public virtual DbSet<ExistingBook> Books { get; set; }

    public virtual DbSet<ExistingGenre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExistingAuthor>(entity =>
        {
            entity.ToTable("Authors");
            entity.HasKey(author => author.AuthorId);
            entity.Property(author => author.Name).HasMaxLength(150).IsRequired();
            entity.Property(author => author.Bio).HasMaxLength(1000);
        });

        modelBuilder.Entity<ExistingBook>(entity =>
        {
            entity.ToTable("Books");
            entity.HasKey(book => book.BookId);
            entity.Property(book => book.Title).HasMaxLength(200).IsRequired();
            entity.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(book => book.Genres)
                .WithMany(genre => genre.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenres",
                    right => right.HasOne<ExistingGenre>().WithMany().HasForeignKey("GenreId"),
                    left => left.HasOne<ExistingBook>().WithMany().HasForeignKey("BookId"));
        });

        modelBuilder.Entity<ExistingGenre>(entity =>
        {
            entity.ToTable("Genres");
            entity.HasKey(genre => genre.GenreId);
            entity.Property(genre => genre.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(genre => genre.Name).IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

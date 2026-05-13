using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace LibraryManagementSystem.Migrations;

[DbContext(typeof(LibraryContext))]
partial class LibraryContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "10.0.1");

        modelBuilder.Entity("LibraryManagementSystem.Models.Author", entity =>
        {
            entity.Property<int>("AuthorId")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER")
                .HasAnnotation("Sqlite:Autoincrement", true);

            entity.Property<string>("Bio")
                .HasMaxLength(1000)
                .HasColumnType("TEXT");

            entity.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("TEXT");

            entity.HasKey("AuthorId");
            entity.ToTable("Authors");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Book", entity =>
        {
            entity.Property<int>("BookId")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER")
                .HasAnnotation("Sqlite:Autoincrement", true);

            entity.Property<int>("AuthorId").HasColumnType("INTEGER");

            entity.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("TEXT");

            entity.HasKey("BookId");
            entity.HasIndex("AuthorId");
            entity.ToTable("Books");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.BookGenre", entity =>
        {
            entity.Property<int>("BookId").HasColumnType("INTEGER");
            entity.Property<int>("GenreId").HasColumnType("INTEGER");

            entity.HasKey("BookId", "GenreId");
            entity.HasIndex("GenreId");
            entity.ToTable("BookGenres");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Genre", entity =>
        {
            entity.Property<int>("GenreId")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER")
                .HasAnnotation("Sqlite:Autoincrement", true);

            entity.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("TEXT");

            entity.HasKey("GenreId");
            entity.HasIndex("Name").IsUnique();
            entity.ToTable("Genres");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Book", entity =>
        {
            entity.HasOne("LibraryManagementSystem.Models.Author", "Author")
                .WithMany("Books")
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.Navigation("Author");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.BookGenre", entity =>
        {
            entity.HasOne("LibraryManagementSystem.Models.Book", "Book")
                .WithMany("BookGenres")
                .HasForeignKey("BookId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne("LibraryManagementSystem.Models.Genre", "Genre")
                .WithMany("BookGenres")
                .HasForeignKey("GenreId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.Navigation("Book");
            entity.Navigation("Genre");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Author", entity =>
        {
            entity.Navigation("Books");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Book", entity =>
        {
            entity.Navigation("BookGenres");
        });

        modelBuilder.Entity("LibraryManagementSystem.Models.Genre", entity =>
        {
            entity.Navigation("BookGenres");
        });
    }
}

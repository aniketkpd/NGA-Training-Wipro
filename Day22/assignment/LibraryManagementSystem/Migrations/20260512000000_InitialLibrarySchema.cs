using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations;

public partial class InitialLibrarySchema : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Authors",
            columns: table => new
            {
                AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                Bio = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authors", x => x.AuthorId);
            });

        migrationBuilder.CreateTable(
            name: "Genres",
            columns: table => new
            {
                GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Genres", x => x.GenreId);
            });

        migrationBuilder.CreateTable(
            name: "Books",
            columns: table => new
            {
                BookId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.BookId);
                table.ForeignKey(
                    name: "FK_Books_Authors_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Authors",
                    principalColumn: "AuthorId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "BookGenres",
            columns: table => new
            {
                BookId = table.Column<int>(type: "INTEGER", nullable: false),
                GenreId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                table.ForeignKey(
                    name: "FK_BookGenres_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BookGenres_Genres_GenreId",
                    column: x => x.GenreId,
                    principalTable: "Genres",
                    principalColumn: "GenreId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_BookGenres_GenreId",
            table: "BookGenres",
            column: "GenreId");

        migrationBuilder.CreateIndex(
            name: "IX_Books_AuthorId",
            table: "Books",
            column: "AuthorId");

        migrationBuilder.CreateIndex(
            name: "IX_Genres_Name",
            table: "Genres",
            column: "Name",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "BookGenres");
        migrationBuilder.DropTable(name: "Books");
        migrationBuilder.DropTable(name: "Genres");
        migrationBuilder.DropTable(name: "Authors");
    }
}

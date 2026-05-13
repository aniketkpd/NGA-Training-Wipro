using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dtos;

public record BookCreateDto([Required, MaxLength(200)] string Title, int AuthorId, [Required] IReadOnlyCollection<int> GenreIds);

public record BookUpdateDto([Required, MaxLength(200)] string Title, int AuthorId, [Required] IReadOnlyCollection<int> GenreIds);

public record BookReadDto(
    int BookId,
    string Title,
    AuthorReadDto? Author,
    IReadOnlyCollection<GenreReadDto> Genres);

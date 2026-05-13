using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dtos;

public record GenreCreateDto([Required, MaxLength(100)] string Name);

public record GenreUpdateDto([Required, MaxLength(100)] string Name);

public record GenreReadDto(int GenreId, string Name);

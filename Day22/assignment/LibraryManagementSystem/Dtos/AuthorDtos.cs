using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dtos;

public record AuthorCreateDto([Required, MaxLength(150)] string Name, [MaxLength(1000)] string? Bio);

public record AuthorUpdateDto([Required, MaxLength(150)] string Name, [MaxLength(1000)] string? Bio);

public record AuthorReadDto(int AuthorId, string Name, string? Bio);

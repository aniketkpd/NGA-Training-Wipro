namespace OnlineBookStoreApi.Models;

public sealed class Author
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Bio { get; set; }
}

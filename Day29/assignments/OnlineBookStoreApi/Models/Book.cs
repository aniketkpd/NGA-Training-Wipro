namespace OnlineBookStoreApi.Models;

public sealed class Book
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public int AuthorId { get; set; }

    public required string AuthorName { get; set; }

    public int PublicationYear { get; set; }
}

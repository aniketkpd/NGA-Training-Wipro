namespace LibraryManagementSystem.DatabaseFirst;

public partial class ExistingBook
{
    public int BookId { get; set; }

    public string Title { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    public virtual ExistingAuthor Author { get; set; } = null!;

    public virtual ICollection<ExistingGenre> Genres { get; set; } = new List<ExistingGenre>();
}

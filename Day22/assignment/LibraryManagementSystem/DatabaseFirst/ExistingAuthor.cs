namespace LibraryManagementSystem.DatabaseFirst;

public partial class ExistingAuthor
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public virtual ICollection<ExistingBook> Books { get; set; } = new List<ExistingBook>();
}

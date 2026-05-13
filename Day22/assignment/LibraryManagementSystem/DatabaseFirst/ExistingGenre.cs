namespace LibraryManagementSystem.DatabaseFirst;

public partial class ExistingGenre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ExistingBook> Books { get; set; } = new List<ExistingBook>();
}

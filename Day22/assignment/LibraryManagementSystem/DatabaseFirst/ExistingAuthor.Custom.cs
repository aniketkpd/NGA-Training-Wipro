namespace LibraryManagementSystem.DatabaseFirst;

public partial class ExistingAuthor
{
    public string DisplayName => string.IsNullOrWhiteSpace(Bio) ? Name : $"{Name} - {Bio}";
}

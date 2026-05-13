using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.ViewModels;

public class LibraryDashboardVm
{
    public IEnumerable<Author> Authors { get; set; } = [];
    public IEnumerable<Genre> Genres { get; set; } = [];
}

using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories.Interfaces;

namespace AdvancedLibraryManagementSystem.Repositories;

public class GenreRepository(LibraryDbContext context) : GenericRepository<Genre>(context), IGenreRepository
{
}

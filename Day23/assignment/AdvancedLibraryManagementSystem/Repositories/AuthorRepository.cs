using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories.Interfaces;

namespace AdvancedLibraryManagementSystem.Repositories;

public class AuthorRepository(LibraryDbContext context) : GenericRepository<Author>(context), IAuthorRepository
{
}

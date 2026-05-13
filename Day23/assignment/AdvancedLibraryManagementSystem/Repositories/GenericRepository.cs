using System.Linq.Expressions;
using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedLibraryManagementSystem.Repositories;

public class GenericRepository<T>(LibraryDbContext context) : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includes.Length > 0)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return orderBy is not null
            ? await orderBy(query).ToListAsync()
            : await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.AsNoTracking().Where(predicate);
        query = includes.Aggregate(query, (current, include) => current.Include(include));
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return;
        }

        _dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
    {
        return filter is null
            ? await _dbSet.CountAsync()
            : await _dbSet.CountAsync(filter);
    }
}

using Microsoft.EntityFrameworkCore;

namespace CommonUtilities.App.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public DbSet<T> DbSet => _dbSet;
}

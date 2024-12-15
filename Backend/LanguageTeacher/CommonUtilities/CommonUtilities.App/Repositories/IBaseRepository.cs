using Microsoft.EntityFrameworkCore;

namespace CommonUtilities.App.Repositories;
public interface IBaseRepository<T> where T : class
{
    public DbSet<T> DbSet { get; }
}

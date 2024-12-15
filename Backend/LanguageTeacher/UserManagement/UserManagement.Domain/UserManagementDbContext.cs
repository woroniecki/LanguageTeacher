using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Domain;
public class UserManagementDbContext : DbContext
{
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
    : base(options) { }

    public DbSet<Account> Accounts { get; set; }
}

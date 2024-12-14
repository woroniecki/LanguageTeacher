using Microsoft.EntityFrameworkCore;

namespace UserManagement.Domain;
public class UserManagementDbContext : DbContext
{
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
    : base(options) { }

}

using CommonUtilities.App.Repositories;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Aggregates;

namespace UserManagement.App.Repositories.Accounts;
public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(DbContext context) : base(context)
    {
    }
}

using Microsoft.Extensions.DependencyInjection;
using UserManagement.App.Repositories.Accounts;

namespace UserManagement.App.Repositories.Extensions;
public static class ConfigurationExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
    }
}

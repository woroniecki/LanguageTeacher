using MediatR;
using Microsoft.Extensions.Configuration;

namespace LanguageTeacher.App.Queries;

public class HealthCheckQueryHandler : IRequestHandler<HealthCheckQuery, string>
{
    private readonly IConfiguration _configuration;

    public HealthCheckQueryHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Handle(HealthCheckQuery request, CancellationToken cancellationToken)
    {
        var mySetting = _configuration["Test"];
        var mySetting2 = _configuration["ConnectionStrings:MySqlDatabaseConnection"];
        return $"HealthCheckQueryTest - SettingValue: {mySetting} {mySetting2}";
    }
}
using MediatR;

namespace LanguageTeacher.App.Queries;

public class HealthCheckQueryHandler : IRequestHandler<HealthCheckQuery, string>
{
    public HealthCheckQueryHandler()
    {
    }

    public async Task<string> Handle(HealthCheckQuery request, CancellationToken cancellationToken)
    {
        return "HealthCheckQueryTest";
    }
}
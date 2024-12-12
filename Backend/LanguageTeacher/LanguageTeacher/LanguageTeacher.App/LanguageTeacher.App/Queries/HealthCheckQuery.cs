using MediatR;

namespace LanguageTeacher.App.Queries;
public class HealthCheckQuery : IRequest<string>
{
    public HealthCheckQuery()
    {

    }
}

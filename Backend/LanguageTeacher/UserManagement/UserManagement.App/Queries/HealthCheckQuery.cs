using MediatR;

namespace UserManagement.App.Queries;
public class HealthCheckQuery : IRequest<string>
{
    public HealthCheckQuery()
    {

    }
}

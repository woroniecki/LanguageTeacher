using CommonUtilities.App.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CommonUtilities.App.PipelineBehaviours.Extensions;
public static class ConfigurationExtension
{
    public static void AddFluentValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>));
    }

    public static void AddTransactionAndDomainEventsBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionAndDomainEventsBehavior<,>));
    }

    public static void AddLoggingBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}

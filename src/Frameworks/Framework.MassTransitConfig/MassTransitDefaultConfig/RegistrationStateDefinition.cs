using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Framework.Commands.MassTransitDefaultConfig;

public class RegistrationStateDefinition<TState,TContext> :
    SagaDefinition<TState> where TState: class, SagaStateMachineInstance where TContext:DbContext
{
    private readonly IServiceProvider _provider;

    public RegistrationStateDefinition(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator,
        ISagaConfigurator<TState> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000));

        endpointConfigurator.UseEntityFrameworkOutbox<TContext>(_provider);
    }

}
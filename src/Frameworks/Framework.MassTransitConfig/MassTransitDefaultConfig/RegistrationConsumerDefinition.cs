using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Framework.Commands.MassTransitDefaultConfig;

public abstract class RegistrationConsumerDefinition<TConsumer,TContext>:ConsumerDefinition<TConsumer> where TConsumer : class, IConsumer where TContext:DbContext
{
    private readonly IServiceProvider _provider;
    
    protected RegistrationConsumerDefinition(IServiceProvider provider)
    {
        _provider = provider;

        // override the default endpoint name
        // EndpointName = "order-service";
    
        // limit the number of messages consumed concurrently
        // this applies to the consumer only, not the endpoint
        ConcurrentMessageLimit = 8;
    }
    
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<TConsumer> consumerConfigurator)
    {
        // configure message retry with millisecond intervals
        endpointConfigurator.UseMessageRetry(r => r.Intervals(100,200,500,800,1000));
    
        // use the outbox to prevent duplicate events from being published
        endpointConfigurator.UseEntityFrameworkOutbox<TContext>(_provider);
    }
}
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.MassTransitConfig.MassTransitDefaultConfig.Bus;

public class BusProducer : IBusProducer
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BusProducer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task ProduceAsync<T>(T message) where T : class
    {
        using var scope = _serviceScopeFactory.CreateScope();


        var producer = scope.ServiceProvider.GetRequiredService<ITopicProducer<T>>();
        await producer.Produce(message);
    }
}
using MassTransit;

namespace Framework.Commands.MassTransitDefaultConfig;

public class UnitOfWorkConsumerConfigurationObserver : IConsumerConfigurationObserver
{
    void IConsumerConfigurationObserver.ConsumerConfigured<T>(IConsumerConfigurator<T> configurator)
    {
    }

    public void ConsumerMessageConfigured<T, TMessage>(IConsumerMessageConfigurator<T, TMessage> configurator)
        where T : class
        where TMessage : class
    {
        var specification = new UnitOfWorkSpecification<T, TMessage>();

        configurator.AddPipeSpecification(specification);
    }
}
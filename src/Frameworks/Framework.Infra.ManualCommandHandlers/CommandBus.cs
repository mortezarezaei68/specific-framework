using Anshan.Framework.Application.Command;
using Framework.Infra.ManualCommandHandlers.EventBus;

namespace Framework.Infra.ManualCommandHandlers
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceLocator _serviceLocator;

        public CommandBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandlerDecorator<T>>();
            await handler.Handle(command);
        }
    }
}
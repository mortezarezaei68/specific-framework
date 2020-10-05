using System.Threading.Tasks;

namespace Framework.CQRS.CommandBus
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
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}
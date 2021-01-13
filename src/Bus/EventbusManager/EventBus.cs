using System.Threading;
using System.Threading.Tasks;
using Framework.Commands.CommandHandlers;
using Framework.Domain.Events;
using MediatR;

namespace Bus.EventbusManager
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IServiceLocator _serviceLocator;

        public EventBus(IMediator mediator, IServiceLocator serviceLocator)
        {
            _mediator = mediator;
            _serviceLocator = serviceLocator;
        }

        public async Task<TResponse> Issue<TResponse>(IRequest<TResponse> command,
            CancellationToken cancellationToken = default) where TResponse : ResponseCommand
        {
            return await _mediator.Send(command, cancellationToken);
        }

        public async Task DomainEventDispatcher<TDomainEvent>(TDomainEvent eventToDispatch) where TDomainEvent : DomainEvent
        {
            await _mediator.Publish(eventToDispatch);
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}
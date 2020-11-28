using System.Threading;
using System.Threading.Tasks;
using EventBase.CommandHandlers;
using EventBase.DomainEvents;
using Framework.CQRS.MediatRCommands;
using MediatR;

namespace EventBase.EventBusBase
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

        public async Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : DomainEvent
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
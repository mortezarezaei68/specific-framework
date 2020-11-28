using System.Threading;
using System.Threading.Tasks;
using EventBase.DomainEvents;
using Framework.CQRS.MediatRCommands;
using MediatR;

namespace EventBase.EventBusBase
{
    public interface IEventBus
    {
        Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default)
            where TResponse : ResponseCommand;

        Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : DomainEvent;
        Task Dispatch<T>(T command);
    }
}
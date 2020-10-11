using System.Threading;
using System.Threading.Tasks;
using Framework.EF.DomainEvents;
using MediatR;

namespace Framework.CQRS.MediatRCommands
{
    public interface IEventBus
    {
        Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default)
            where TResponse : ResponseCommand;

        Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
        Task Dispatch<T>(T command);
    }
}
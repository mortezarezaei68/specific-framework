using System.Threading;
using System.Threading.Tasks;
using Framework.Commands.CommandHandlers;
using Framework.Domain.Events;
using MediatR;

namespace Bus.EventbusManager
{
    public interface IEventBus
    {
        Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default)
            where TResponse : ResponseCommand;

        Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : DomainEvent;
    }
}
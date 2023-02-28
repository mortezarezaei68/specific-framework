using Framework.Domain.Core;
using MediatR;

namespace Framework.Infra.MediatR.EventBusManagement
{
    public interface IEventBus
    {
        Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default)
            where TResponse : class;
        Task<TResponse> IssueQuery<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken = default)
            where TResponse : class;
        Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;

    }
}
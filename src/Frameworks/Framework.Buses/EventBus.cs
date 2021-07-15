using System.Threading;
using System.Threading.Tasks;
using Framework.Commands.CommandHandlers;
using Framework.Domain.Core;
using Framework.Queries;
using MediatR;

namespace Framework.Buses
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Issue<TResponse>(IRequest<TResponse> command,
            CancellationToken cancellationToken = default) where TResponse : ResponseCommand
        {
            return await _mediator.Send(command, cancellationToken);
        }

        public async Task<TResponse> IssueQuery<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken = default) where TResponse : BaseResponseQuery
        {
            return await _mediator.Send(query, cancellationToken);
        }

        public async Task DomainEventDispatcher<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            await _mediator.Publish(eventToDispatch);
        }
        
    }
}
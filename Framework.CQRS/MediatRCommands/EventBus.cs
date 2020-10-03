using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Framework.CQRS.MediatRCommands
{
    public class EventBus:IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default) where TResponse : ResponseCommand
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
using System.Threading.Tasks;
using MediatR;

namespace Framework.EF.DomainEvents
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;

        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            await _mediator.Publish(eventToDispatch);
        }
    }
}
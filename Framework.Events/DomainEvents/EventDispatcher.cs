using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.CQRS.DecoratorCommandBus;
using MediatR;

namespace Framework.EF.DomainEvents
{
    public class EventDispatcher:IEventDispatcher
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly IMediator _mediator;

        public EventDispatcher(IServiceLocator serviceLocator, IMediator mediator)
        {
            _serviceLocator = serviceLocator;
            _mediator = mediator;
        }

        public async Task Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            // foreach (dynamic handler in GetHandlers(eventToDispatch))
            // {
            //     handler.Handle((dynamic)eventToDispatch);
            // }
            _mediator.Publish(eventToDispatch);
        }

        // private dynamic GetHandlers<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        // {
        //     // return (IEnumerable) _lifetimeScope.Resolve(
        //     //     typeof(IEnumerable<>).MakeGenericType(
        //     //         typeof(IDomainEventHandler<>).MakeGenericType(eventToDispatch.GetType())));
        //     var data = _serviceLocator.GetInstances<IDomainEventHandler<TEvent>>();
        //     return data;
        // }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Framework.EF.DomainEvents
{
    public class EventDispatcher:IEventDispatcher
    {
        private readonly IServiceLocator _serviceLocator;

        public EventDispatcher(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (dynamic handler in GetHandlers(eventToDispatch))
            {
                handler.Handle((dynamic)eventToDispatch);
            }
        }

        private IEnumerable GetHandlers<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            // return (IEnumerable) _lifetimeScope.Resolve(
            //     typeof(IEnumerable<>).MakeGenericType(
            //         typeof(IDomainEventHandler<>).MakeGenericType(eventToDispatch.GetType())));
            return (IEnumerable) _serviceLocator.GetInstance<IDomainEventHandler<TEvent>>();
        }
    }
}
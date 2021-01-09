using MediatR;

namespace EventBase.DomainEvents
{
    public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
    }
}
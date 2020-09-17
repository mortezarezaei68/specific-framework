using MediatR;

namespace Framework.EF.DomainEvents
{
    public interface IDomainEventHandler<in TDomainEvent>:INotificationHandler<TDomainEvent> where TDomainEvent:IDomainEvent 
    {
        
    }
}
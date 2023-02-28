using System.Collections.Generic;
namespace Framework.Domain.Core
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<DomainEvent>? DomainEvents { get; }
        void AddDomainEvent(DomainEvent eventItem);
        void RemoveDomainEvent(DomainEvent eventItem);
        void ClearDomainEvents();
    }
}
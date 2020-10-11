using System;
using MediatR;

namespace Framework.EF.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        Guid Id => Guid.NewGuid();
        DateTime CreatedAt { get; set; }
        string EventName { get; }
    }
}
using System;
using MediatR;

namespace EventBase.DomainEvents
{
    public class DomainEvent : INotification
    {
        Guid Id => Guid.NewGuid();
        DateTime CreatedAt { get; set; }
        string EventName { get; }
    }
}
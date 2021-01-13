using System;
using MediatR;

namespace Framework.Domain.Events
{
    public class DomainEvent : INotification
    {
        Guid Id => Guid.NewGuid();
        DateTime CreatedAt { get; set; }
        string EventName { get; }
    }
}
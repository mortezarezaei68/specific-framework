using MediatR;

namespace Framework.Infra.MediatR
{
    public interface IDomainEvent : INotification
    {
        Guid Id => Guid.NewGuid();
        DateTime CreatedAt =>DateTime.Now;
        string EventName { get; }
    }
}
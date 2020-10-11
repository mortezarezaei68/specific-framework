using System.Threading;
using System.Threading.Tasks;
using Framework.EF.DomainEvents;
using Framework.EF.DomainEvents.DomainEventAbstract;

namespace Framework.Events.DomainEvents.DomainEventAbstract
{
    public class DeleteStatusCustomerDomainEventHandler : IDomainEventHandler<ChangedStatusCustomerDomainEvent>
    {
        public Task Handle(ChangedStatusCustomerDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
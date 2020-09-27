using System;

namespace Framework.EF.DomainEvents.DomainEventAbstract
{
    public class ChangedStatusCustomerDomainEvent:IDomainEvent
    {
        public ChangedStatusCustomerDomainEvent(Customer customer)
        {
            Customer = customer;
        }
        public DateTime CreatedAt { get; set; }
        public string EventName => nameof(Customer);
        public Customer Customer { get; private set; }
    }
}
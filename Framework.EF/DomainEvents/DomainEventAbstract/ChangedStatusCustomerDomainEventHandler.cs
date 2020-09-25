using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Framework.EF.DomainEvents.DomainEventAbstract
{
    public class ChangedStatusCustomerDomainEventHandler:IDomainEventHandler<ChangedStatusCustomerDomainEvent>
    {
        private readonly ILoggerFactory _loggerFactory;

        public ChangedStatusCustomerDomainEventHandler(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async Task Handle(ChangedStatusCustomerDomainEvent notification, CancellationToken cancellationToken)
        {
            _loggerFactory.CreateLogger<ChangedStatusCustomerDomainEvent>().LogTrace("test data");
        }
    }
}
using System;
using Framework.Domain.DomainConfig;

namespace Microservice.Domain
{
    public class Product : AggregateRoot<Guid>
    {
        public Product(string productName)
        {
            ProductName = productName;
        }


        // Empty constructor for EF
        protected Product()
        {
        }

        public string ProductName { get; private set; }
    }
}
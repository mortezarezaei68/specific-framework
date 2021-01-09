using System;
using Framework.Domain.DomainConfig;

namespace Microservice.Domain
{
    public class Product : AggregateRoot<int>
    {
        private Product()
        {

        }
        
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        
        public static Product Add(string productName, string description)
        {
            return new Product()
            {
                ProductName = productName,
                Description = description
            };
        }

        public void Update(string productName, string description)
        {
            ProductName = productName;
            Description = description;
        }

    }
}
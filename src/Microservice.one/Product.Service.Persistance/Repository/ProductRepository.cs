using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Domain;
using Persistance.EfCore.Context;

namespace Persistance.EfCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContextDb _context;

        public ProductRepository(ApplicationContextDb context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Customers.Add(product);
            return product;
        }
    }
}
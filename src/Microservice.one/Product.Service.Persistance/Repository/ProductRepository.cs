using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;
using Microservice.Domain;
using Persistance.EfCore.Context;
using Persistance.EfCore.UnitOfWork;

namespace Persistance.EfCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContextDb _context;
        private readonly UnitOfWork<ApplicationContextDb> _unitOfWork;

            public ProductRepository(ApplicationContextDb context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;
    }
}
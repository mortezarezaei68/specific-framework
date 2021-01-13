using Framework.Domain.UnitOfWork;
using ProductService.Domain;
using ProductService.Persistance.Context;
using ProductService.Persistance.UnitOfWork;

namespace ProductService.Persistance.Repository
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
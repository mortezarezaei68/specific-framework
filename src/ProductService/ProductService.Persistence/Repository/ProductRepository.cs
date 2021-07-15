using Framework.Domain.UnitOfWork;
using ProductService.Domain;
using ProductService.Persistence.Context;
using ProductService.Persistence.UnitOfWork;

namespace ProductService.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContextDb _context;
        private readonly UnitOfWork<ApplicationContextDb> _unitOfWork;

            public ProductRepository(ApplicationContextDb context, UnitOfWork<ApplicationContextDb> unitOfWork)
            {
                _context = context;
                _unitOfWork = unitOfWork;
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
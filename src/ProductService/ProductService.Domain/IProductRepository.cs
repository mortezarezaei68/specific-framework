using Framework.Domain.UnitOfWork;

namespace ProductService.Domain
{
    public interface IProductRepository:IRepository
    {
        global::ProductService.Domain.Product Add(global::ProductService.Domain.Product product);
        void Update(global::ProductService.Domain.Product product);
    }
}
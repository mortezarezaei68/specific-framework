using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Domain
{
    public interface IProductRepository:IRepository
    {
        Product Add(Product product);
        void Update(Product product);
    }
}
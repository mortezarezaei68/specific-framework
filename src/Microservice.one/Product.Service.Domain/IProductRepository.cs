using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Domain
{
    public interface IProductRepository
    {
        Product Add(Product product);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.EF
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Task<IEnumerable<Customer>> GetMachCustomer(IEnumerable<Customer> customers);
    }
}
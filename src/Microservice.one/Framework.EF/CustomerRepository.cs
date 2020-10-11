using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContextDb _context;

        public CustomerRepository(ApplicationContextDb context)
        {
            _context = context;
        }

        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetMachCustomer(IEnumerable<Customer> customers)
        {
            return null;
        }
    }
}
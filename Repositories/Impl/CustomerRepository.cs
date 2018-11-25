using Interfaces.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyDbContext context) : base(context)
        {

        }

        public IEnumerable<Customer> GetAllActive()
        {
            return _context.Customers.Where(a => a.IsActive == true).ToList();
        }
    }
}

using Models;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAllActive();
    }
}

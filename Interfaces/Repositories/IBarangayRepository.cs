using Models;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface IBarangayRepository : IRepository<Barangay>
    {
        IEnumerable<Barangay> GetAllActive();
    }
}

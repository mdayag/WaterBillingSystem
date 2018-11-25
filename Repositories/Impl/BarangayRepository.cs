using Models;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Repositories;

namespace Repositories
{
    public class BarangayRepository : Repository<Barangay>, IBarangayRepository
    {
        public BarangayRepository(MyDbContext context) : base(context) {
            
        }

        public IEnumerable<Barangay> GetAllActive()
        {
            return _context.Barangays.Where(a => a.IsActive == true).ToList();
        }
    }
}

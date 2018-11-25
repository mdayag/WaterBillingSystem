using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Interfaces.Repositories;

namespace Repositories.Impl
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

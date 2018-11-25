using ViewModels;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IBarangayService
    {
        IList<BarangayViewModel> GetAll();
        BarangayViewModel Get(int id);
        bool Save(BarangayViewModel viewModel);
        bool Update(BarangayViewModel viewModel);
        bool Delete(int id);
    }
}

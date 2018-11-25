using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ViewModels;

namespace Interfaces.Services
{
    public interface ICustomerService
    {
        IList<CustomerViewModel> GetAll();
        CustomerViewModel Get(int id);
        bool Save(CustomerViewModel viewModel);
        bool Update(CustomerViewModel viewModel);
        bool Delete(int id);
        SelectList GetGenders();
        SelectList GetCivilStatus();
        SelectList GetAccountTypes();
    }
}

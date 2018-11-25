using Interfaces.Repositories;
using Interfaces.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace Services
{
    public class BarangayService : IBarangayService
    {
        #region Members

        private readonly IBarangayRepository _barangayRepository;

        #endregion Members

        #region Constructor

        public BarangayService(IBarangayRepository barangayRepository)
        {
            _barangayRepository = barangayRepository;
        }

        #endregion Constructor

        #region Events

        public IList<BarangayViewModel> GetAll()
        {
            var vm = new List<BarangayViewModel>();

            try
            {
                var model = _barangayRepository.GetAllActive();

                vm = model.Select(m => new BarangayViewModel
                {
                    BarangayId = m.BarangayId,
                    Code = m.Code,
                    Name = m.Name
                }).ToList();
            }
            catch (Exception ex)
            {

            }

            return vm;
        }

        public BarangayViewModel Get(int id)
        {
            try
            {
                var model = _barangayRepository.GetById(id);

                var viewModel = new BarangayViewModel
                {
                    BarangayId = model.BarangayId,
                    Code = model.Code,
                    Name = model.Name
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Save(BarangayViewModel viewModel)
        {
            try
            {
                var model = new Barangay()
                {
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    IsActive = true,
                    //CreatedById = 1,
                    CreatedDate = DateTime.Now
                };

                _barangayRepository.Create(model);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(BarangayViewModel viewModel)
        {
            try
            {
                var model = _barangayRepository.GetById(viewModel.BarangayId);

                model.Code = viewModel.Code;
                model.Name = viewModel.Name;
                //model.UpdatedById = 1;
                model.UpdatedDate = DateTime.Now;

                _barangayRepository.Update(model);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _barangayRepository.GetById(id);

                model.IsActive = false;
                //model.DeletedById = 1;
                model.DeletedDate = DateTime.Now;

                _barangayRepository.Update(model);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Events
    }
}

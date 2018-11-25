using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Enums;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        #region Members

        private readonly ICustomerRepository _customerRepository;

        #endregion Members

        #region Constructor

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion Constructor

        #region Events

        public IList<CustomerViewModel> GetAll()
        {
            var vm = new List<CustomerViewModel>();

            try
            {
                var model = _customerRepository.GetAllActive();

                vm = model.Select(m => new CustomerViewModel
                {
                    LastName = m.LastName,
                    FirstName = m.FirstName,
                    MiddleName = m.MiddleName,
                    DateOfBirth = m.DateOfBirth,
                    GenderId = m.GenderId,
                    CivilStatusId = m.CivilStatusId,
                    BarangayId = m.BarangayId,
                    AccountTypeId = m.AccountTypeId
                }).ToList();
            }
            catch (Exception ex)
            {

            }

            return vm;
        }

        public CustomerViewModel Get(int id)
        {
            try
            {
                var model = _customerRepository.GetById(id);

                var viewModel = new CustomerViewModel()
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    DateOfBirth = model.DateOfBirth,
                    GenderId = model.GenderId,
                    CivilStatusId = model.CivilStatusId,
                    BarangayId = model.BarangayId,
                    AccountTypeId = model.AccountTypeId
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Save(CustomerViewModel viewModel)
        {
            try
            {
                var model = new Customer()
                {
                    LastName = viewModel.LastName,
                    FirstName = viewModel.FirstName,
                    MiddleName = viewModel.MiddleName,
                    DateOfBirth = viewModel.DateOfBirth,
                    GenderId = viewModel.GenderId,
                    CivilStatusId = viewModel.CivilStatusId,
                    BarangayId = viewModel.BarangayId,
                    AccountTypeId = viewModel.AccountTypeId,
                    IsActive = true,
                    //CreatedById = 1,
                    CreatedDate = DateTime.Now
                };

                _customerRepository.Create(model);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(CustomerViewModel viewModel)
        {
            try
            {
                var model = _customerRepository.GetById(viewModel.BarangayId);

                model.LastName = viewModel.LastName;
                model.FirstName = viewModel.FirstName;
                model.MiddleName = viewModel.MiddleName;
                model.DateOfBirth = viewModel.DateOfBirth;
                model.GenderId = viewModel.GenderId;
                model.CivilStatusId = viewModel.CivilStatusId;
                model.BarangayId = viewModel.BarangayId;
                model.AccountTypeId = viewModel.AccountTypeId;
                //model.UpdatedById = 1;
                model.UpdatedDate = DateTime.Now;

                _customerRepository.Update(model);

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
                var model = _customerRepository.GetById(id);

                model.IsActive = false;
                //model.DeletedById = 1;
                model.DeletedDate = DateTime.Now;

                _customerRepository.Update(model);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SelectList GetGenders()
        {
            var genders = from Gender g in Enum.GetValues(typeof(Gender))
                         select new { Id = (int)g, Name = GetEnumDescription(g) };

            var genderList = new SelectList(genders, "Id", "Name", string.Empty);

            return genderList;
        }

        public SelectList GetCivilStatus()
        {
            var civilStatus = from CivilStatus c in Enum.GetValues(typeof(CivilStatus))
                          select new { Id = (int)c, Name = GetEnumDescription(c) };

            var civilStatusList = new SelectList(civilStatus, "Id", "Name", string.Empty);

            return civilStatusList;
        }

        public SelectList GetAccountTypes()
        {
            var accountTypes = from AccountType a in Enum.GetValues(typeof(AccountType))
                              select new { Id = (int)a, Name = GetEnumDescription(a) };

            var accountTypeList = new SelectList(accountTypes, "Id", "Name", string.Empty);

            return accountTypeList;
        }

        #endregion Events
    }
}

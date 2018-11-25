using System;

namespace ViewModels
{
    public class CustomerViewModel: BaseViewModel
    {
        #region Properties

        public int CustomerId { get; set; } = 0;

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public int GenderId { get; set; } = 0;

        public int CivilStatusId { get; set; } = 0;

        public int BarangayId { get; set; } = 0;

        public int AccountTypeId { get; set; } = 0;

        #endregion Properties
    }
}

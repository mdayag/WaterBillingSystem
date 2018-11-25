using System;

namespace Models
{
    public class BaseModel
    {
        #region Properties

        public bool IsActive { get; set; } = true;

        public int CreatedById { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedById { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? DeletedById { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? RestoredById { get; set; }

        public DateTime? RestoredDate { get; set; }

        #endregion Properties
    }
}

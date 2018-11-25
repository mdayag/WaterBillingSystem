namespace Models
{
    public class Barangay: BaseModel
    {
        #region Properties

        public int BarangayId { get; set; } = 0;

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        #endregion Properties
    }
}

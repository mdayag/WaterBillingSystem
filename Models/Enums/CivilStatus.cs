using System.ComponentModel;

namespace Models.Enums
{
    public enum CivilStatus
    {
        [Description("Single")]
        Single = 1,

        [Description("Married")]
        Married = 2,

        [Description("Widow")]
        Widow = 3,

        [Description("Separated")]
        Separated = 4,

        [Description("Divorsed")]
        Divorsed = 5,

        [Description("None")]
        None = 6,
    }
}

using System.ComponentModel;

namespace Models.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,

        [Description("None")]
        None = 3,
    }
}

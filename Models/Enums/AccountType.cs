using System.ComponentModel;

namespace Models.Enums
{
    public enum AccountType
    {
        [Description("Normal")]
        Normal = 1,

        [Description("Commercial")]
        Commercial = 2,

        [Description("Free")]
        Free = 3,
    }
}

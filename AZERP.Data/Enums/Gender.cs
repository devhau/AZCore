using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum Gender : int
    {
        [Field(Display = "Nam")] Male = 1, 
        [Field(Display = "Nữ")] Female = 2,
        [Field(Display = "Khác")] Other = 3,
    }
}

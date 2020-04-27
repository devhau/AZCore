using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
        [Field(Display ="Tao thử mày thôi")]
        Demo,
        [Field(Display = "Khu nhà trọ")]
        AreaCode
    }
}

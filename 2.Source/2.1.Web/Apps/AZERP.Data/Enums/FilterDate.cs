using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum FilterDate
    {
        [Field(Display = "Ngày")]
        Day,
        [Field(Display = "Tháng")]
        Month,
        [Field(Display = "Năm")]
        Year
    }
}

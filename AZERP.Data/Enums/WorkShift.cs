using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    //day shift; night shift
    public enum WorkShift:int
    {
        [Field(Display = "Ca ngày")] DayShift = 1,
        [Field(Display = "Ca đêm")]  NightShift = 2,
        [Field(Display = "Nghỉ phép")] NghiPhep = 3,
        [Field(Display = "Nghỉ không lương")] NghiKhongLuong = 4,
        //[Field(Display = "Ca 1")]    OneShift = 3,
        //[Field(Display = "Ca 2")]    TwoShift = 4,
        //[Field(Display = "Ca 3")]    ThreeShift = 5
    }
}

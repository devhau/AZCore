using AZCore.Database.Attr;

namespace AZERP.Data.Enums
{
    public enum EnumTypeOfCandidate:int
    {
        [Field(Display = "Chưa chọn loại")] None = 0,//Default
        [Field(Display = "Chính Thức")] ChinhThuc = 1,//Chính Thức
        [Field(Display = "Thời vụ")] ThoiVu = 2,//Chính Thức
        [Field(Display = "Thế nào cũng được")] Other = 3,//Cả 2 cái nào cũng được
    }
}

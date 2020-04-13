using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum TypeOfCandidate:int
    {
        [Field(Display = "Chính Thức")] ChinhThuc = 1,//Chính Thức
        [Field(Display = "Thời vụ")] ThoiVu = 2,//Chính Thức
        [Field(Display = "Thế nào cũng được")] Other = 3,//Cả 2 cái nào cũng được
    }
}

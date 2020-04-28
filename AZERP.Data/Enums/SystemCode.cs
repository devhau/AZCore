using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
        [Field(Display = "Khu nhà trọ")]
        AreaCode,
        [Field(Display ="Ứng viên tuyển dụng")]
        CandidateCode,
        [Field(Display = "Công nhân")]
        WorkerCode,
        [Field(Display = "Cộng tác viên tuyển dụng")]
        CollaboratorCode, 
    }
}

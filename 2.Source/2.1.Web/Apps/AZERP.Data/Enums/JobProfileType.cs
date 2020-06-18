using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum JobProfileType:int
    {
        [Field(Display ="Công nhân")]
        Worker, 
        [Field(Display = "Tuyển dụng")]
        Recruitment,
        [Field(Display = "Cộng tác viên")]
        Collaborators
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// Nghề nghiệp
    /// vd: Lắp giáp linh kiện điện tử
    /// </summary>
    [TableInfo(TableName = "az_recruitment_professions")]
    public class JobProfessions : EntityTenantModel<JobProfessions, long>
    {
        [Field(Length = 255)]
        public string Name {get;set;}
    }
}

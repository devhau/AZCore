using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_permission")]
    public class AZPermission : ITenantEntity
    {
        [Field]
        public string KeyName { get; set; }
        [Field(IsKey =true,Length =50)]
        public string Code { get; set; }
        [Field(Length =128)]
        public string Name { get; set; }
        [Field]
        public long? TenantId { get; set; }
    }
}

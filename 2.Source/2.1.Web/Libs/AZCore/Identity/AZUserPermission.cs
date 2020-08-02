using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_user_permission")]
    public class AZUserPermission : ITenantEntity
    {
        [Field]
        public long? TenantId { get; set; }
        [Field(IsKey = true)]
        public long UserId { get; set; }
        [Field(IsKey = true, Length = 50)]
        public string PermissionCode { get; set; }

    }
}

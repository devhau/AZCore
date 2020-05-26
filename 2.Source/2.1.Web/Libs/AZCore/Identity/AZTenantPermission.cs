using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_tenant_permission")]
    public class AZTenantPermission<TEntity> : ITenantEntity
    {
        [Field(IsKey = true)]
        public long? TenantId { get; set; }
        [Field(IsKey = true, Length = 50)]
        public string PermissionCode { get; set; }
    }
}

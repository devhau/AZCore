using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_user")]
    public class AZTenantUser<TEntity> : IEntity where TEntity : AZTenantUser<TEntity>
    {
        [Field(IsKey = true)]
        public long TenantId { get; set; }
        [Field(IsKey = true)]
        public long UserId { get; set; }
        
    }
}

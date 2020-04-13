using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_role")]
    public class AZTenantRole<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZTenantRole<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey RoleId { get; set; }
       
    }
}

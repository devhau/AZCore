using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_role_permission")]
    public class AZRolePermission<TEntity> : IEntity
    {
        [Field(IsKey =true)]
        public long RoleId { get; set; }
        [Field(IsKey = true,Length =50)]
        public string PermissionCode { get; set; }
      
    }
}

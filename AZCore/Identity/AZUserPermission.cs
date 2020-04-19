using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user_permission")]
    public class AZUserPermission<TEntity> : IEntity
    {
        [Field(IsKey = true)]
        public long UserId { get; set; }
        [Field(IsKey = true, Length = 50)]
        public long PermissionId { get; set; }

    }
}

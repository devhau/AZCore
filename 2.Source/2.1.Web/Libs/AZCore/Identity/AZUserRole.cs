using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_user_role")]
    public class AZUserRole<TEntity> : IEntity
    {
        [Field(IsKey = true)]
        public long UserId { get; set; }
        [Field(IsKey = true)]
        public long RoleId { get; set; }
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user_role")]
    public class AZUserRole<TEntity> : IEntity where TEntity : AZUserRole<TEntity>
    {
        [Field(IsKey = true)]
        public long UserId { get; set; }
        [Field(IsKey = true)]
        public long RoleId { get; set; }
    }
}

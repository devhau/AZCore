using AZCore.Database;
using AZCore.Database.Attr;
using System.Data;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user_permission")]
    public class AZUserPermission<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZUserPermission<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey UserId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
       
    }
}

using AZCore.Database;
using AZCore.Database.Attr;
using System.Data;

namespace AZCore.Identity
{
    public class AZUserPermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZUserPermission<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey UserId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
        public AZUserPermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

using AZCore.Database;
using System.Data;

namespace AZCore.Identity
{
    public class AZUserPermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZUserPermission<TEntity, TKey>
    {
        public AZUserPermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

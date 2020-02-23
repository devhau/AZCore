using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZRolePermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZRolePermission<TEntity, TKey>
    {
        public AZRolePermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantPermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantPermission<TEntity, TKey>
    {
        public AZTenantPermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

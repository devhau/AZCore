using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantUser<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantUser<TEntity, TKey>
    {
        public AZTenantUser(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

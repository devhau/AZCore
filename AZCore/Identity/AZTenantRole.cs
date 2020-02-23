using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantRole<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantRole<TEntity, TKey>
    {
        public AZTenantRole(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

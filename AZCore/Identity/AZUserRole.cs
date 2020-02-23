using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZUserRole<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZUserRole<TEntity, TKey>
    {
        public AZUserRole(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantUser<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantUser<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey UserId { get; set; }
        public AZTenantUser(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

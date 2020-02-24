using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantRole<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantRole<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey RoleId { get; set; }
        public AZTenantRole(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

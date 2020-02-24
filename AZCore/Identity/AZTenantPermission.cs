using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZTenantPermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZTenantPermission<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
        public AZTenantPermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

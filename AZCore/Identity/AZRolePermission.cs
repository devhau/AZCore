using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    public class AZRolePermission<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity : AZRolePermission<TEntity, TKey>
    {
        [Field(IsKey =true)]
        public TKey RoleId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
        public AZRolePermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

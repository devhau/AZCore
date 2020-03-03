using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_role_permission")]
    public class AZRolePermission<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZRolePermission<TEntity, TKey>
    {
        [Field(IsKey =true)]
        public TKey RoleId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
      
    }
}

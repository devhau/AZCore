using AZCore.Database;
using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_permission")]
    public class AZTenantPermission<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZTenantPermission<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey PermissionId { get; set; }
       
    }
}

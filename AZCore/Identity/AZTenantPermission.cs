﻿using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_permission")]
    public class AZTenantPermission<TEntity, TKey> : IEntity
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public long PermissionId { get; set; }

    }
}

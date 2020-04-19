﻿using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_role")]
    public class AZTenantRole<TEntity> : IEntity
    {
        [Field(IsKey = true)]
        public long TenantId { get; set; }
        [Field(IsKey = true)]
        public long RoleId { get; set; }
       
    }
}

using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_role")]
    public class AZTenantRole<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZTenantRole<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey RoleId { get; set; }
       
    }
}

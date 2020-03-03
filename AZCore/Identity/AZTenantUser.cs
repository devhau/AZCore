using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant_user")]
    public class AZTenantUser<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZTenantUser<TEntity, TKey>
    {
        [Field(IsKey = true)]
        public TKey TenantId { get; set; }
        [Field(IsKey = true)]
        public TKey UserId { get; set; }
        
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user_role")]
    public class AZUserRole<TEntity, TKey> : EntityModel<TEntity> where TEntity : AZUserRole<TEntity, TKey>
    {

        [Field(IsKey = true)]
        public TKey UserId { get; set; }
        [Field(IsKey = true)]
        public TKey RoleId { get; set; }
    }
}

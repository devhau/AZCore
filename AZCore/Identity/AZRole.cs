using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_role")]
    public class AZRole<TEntity, TKey> : EntityModel<TEntity, TKey> where TEntity: AZRole<TEntity, TKey>
    {
        [Field]
        public string Name { get; set; }
       
    }
}

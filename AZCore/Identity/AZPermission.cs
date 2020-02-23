using AZCore.Database;
using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Identity
{
    [TableInfo(TableName ="az_permission")]
    public class AZPermission<TEntity,TKey> : EntityBase<TEntity, TKey> where TEntity: AZPermission<TEntity, TKey>
    {
        [Field]
        public string Name { get; set; }
        public AZPermission(IDbConnection _connection) : base(_connection)
        {
        }
    }
}

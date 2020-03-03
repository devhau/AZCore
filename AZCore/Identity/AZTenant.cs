using AZCore.Database;
using AZCore.Database.Attr;
using System.Data;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant")]
    public class AZTenant<TEntity,TKey> : EntityModel<TEntity, TKey> where  TEntity: AZTenant<TEntity, TKey>
    {
        [Field]
        public string Name { get; set; }
        public string SubDomain { get; set; }
       
    }
}

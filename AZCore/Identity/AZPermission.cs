using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName ="az_permission")]
    public class AZPermission<TEntity,TKey> : EntityModel<TEntity, TKey> where TEntity: AZPermission<TEntity, TKey>
    {
        [Field]
        public string Code { get; set; }
        [Field]
        public string Name { get; set; }
      
    }
}

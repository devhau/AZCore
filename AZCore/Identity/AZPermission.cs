using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName ="az_permission")]
    public class AZPermission<TEntity> : EntityModel<TEntity,long> where TEntity: AZPermission<TEntity>
    {
        [Field]
        public string Key { get; set; }
        [Field(Length =50)]
        public string Code { get; set; }
        [Field(Length =128)]
        public string Name { get; set; }
      
    }
}

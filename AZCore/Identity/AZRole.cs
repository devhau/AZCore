using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_role")]
    public class AZRole<TEntity, TKey> : EntityModel<TEntity, TKey> where TEntity: AZRole<TEntity, TKey>
    {
        [FieldDisplay]
        [Field]
        public string Name { get; set; }
       
    }
}

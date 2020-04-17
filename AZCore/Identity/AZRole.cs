using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_role")]
    public class AZRole<TEntity> : EntityModel<TEntity, long> where TEntity: AZRole<TEntity>
    {
        [FieldDisplay]
        [Field(Length = 200)]
        public string Name { get; set; }
       
    }
}

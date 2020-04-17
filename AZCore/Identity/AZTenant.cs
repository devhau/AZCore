using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant")]
    public class AZTenant<TEntity> : EntityModel<TEntity, long> where  TEntity: AZTenant<TEntity>
    {
        [Field(Length = 200)]
        public string Name { get; set; }
        [Field(Length = 200)]
        public string SubDomain { get; set; }
       
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_role")]
    public class AZRole : EntityModel<long>
    {
        [FieldDisplay]
        [Field(Length = 200)]
        public string Name { get; set; }
       
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class ModuleService : EntityService<ModuleService, ModuleModel>, IAZTransient
    {
        public ModuleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>
    [TableInfo(TableName = "az_module")]
    public class ModuleModel : EntityModel<ModuleModel, long>
    {
        /// <summary>
        /// Tên module
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Mã code
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
    }
    [TableInfo(TableName = "az_module_permssion")]
    public class ModulePermssionModel : EntityModel<ModulePermssionModel, long>
    {   
        [Field]
        public long ModuleId { get; set; }
        [Field]
        public long PermissionId { get; set; }
    }
}

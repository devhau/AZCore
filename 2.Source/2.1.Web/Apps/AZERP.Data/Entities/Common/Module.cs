using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class ModuleService : EntityService<ModuleService, ModuleModel>, IAZTransient
    {
        public ModuleService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>
    [TableInfo(TableName = "az_common_module")]
    public class ModuleModel : EntityTenantModel<ModuleModel, long>
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
    [TableInfo(TableName = "az_common_module_permssion")]
    public class ModulePermssionModel : IEntity
    {
        [Field(IsKey = true)]
        public long ModuleId { get; set; }
        [Field(IsKey = true, Length = 50)]
        public string PermissionCode { get; set; }
        public long TenantId { get; set; }
    }
}

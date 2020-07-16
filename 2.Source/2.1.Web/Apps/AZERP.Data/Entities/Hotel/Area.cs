using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class AreaService : EntityService<AreaService, AreaModel>, IAZTransient
    {
        public AreaService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của khu vực
    /// </summary>

    [TableInfo(TableName = "az_hotel_area")]
    public class AreaModel : EntityTenantModel<AreaModel, long>
    {
        /// <summary>
        /// Mã khu vực/ tòa nhà
        /// </summary>
        [FieldAutoGenCode(Key =SystemCode.AreaCode)]
        [Field]
        public string AreaCode { get; set; }
        /// <summary>
        /// Tên khu vực/ tòa nhà
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string AreaName { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

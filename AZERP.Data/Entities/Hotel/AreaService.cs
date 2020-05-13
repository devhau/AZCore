using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class AreasService : EntityService<AreasService, AreaServiceModel>, IAZTransient
    {
        public AreasService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin dịch vụ cho phòng
    /// </summary>

    [TableInfo(TableName = "az_hotel_area_service")]
    public class AreaServiceModel : EntityModel<AreaServiceModel, long>
    {
        /// <summary>
        /// Mã dịch vụ khu vực
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.AreasService)]
        [Field]
        public long AreaServiceID { get; set; }
        /// <summary>
        /// Mã dịch vụ chung
        /// </summary>
        [Field]
        [FieldDisplay]
        public long CommonServiceID { get; set; }
        /// <summary>
        /// Mã khu vực
        /// </summary>
        [Field]
        [FieldDisplay]
        public long AreaID { get; set; }
        /// <summary>
        /// Đơn giá
        /// </summary>
        [Field]
        public decimal Price { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

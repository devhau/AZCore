using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class RegionalService : EntityService<RegionalService, RegionalServiceModel>, IAZTransient
    {
        public RegionalService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin dịch vụ cho phòng
    /// </summary>

    [TableInfo(TableName = "az_hotel_regionalservice")]
    public class RegionalServiceModel : EntityModel<RegionalServiceModel, long>
    {
        /// <summary>
        /// Mã dịch vụ cho khu vực
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.RegionalService)]
        [Field(Length = 500)]
        public string RegionalServiceID { get; set; }
        /// <summary>
        /// Tên dịch vụ cho khu vực
        /// </summary>
        [Field]
        [FieldDisplay]
        public long CommonServiceID { get; set; }
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

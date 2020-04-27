using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CommonService : EntityService<CommonService, CommonServiceModel>, IAZTransient
    {
        public CommonService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin dịch vụ cho phòng
    /// </summary>

    [TableInfo(TableName = "az_hotel_commonservice")]
    public class CommonServiceModel : EntityModel<CommonServiceModel, long>
    {
        /// <summary>
        /// Mã dịch vụ cho khu vực
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.CommonServiceCode)]
        [Field(Length = 500)]
        public string CommonServiceID { get; set; }
        /// <summary>
        /// Tên dịch vụ cho khu vực
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string CommonServiceName { get; set; }
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

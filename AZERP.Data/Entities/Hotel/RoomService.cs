using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class RoomService : EntityService<RoomService, RoomServiceModel>, IAZTransient
    {
        public RoomService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin dịch vụ cho phòng
    /// </summary>

    [TableInfo(TableName = "az_hotel_roomservice")]
    public class RoomServiceModel : EntityModel<RoomServiceModel, long>
    {
        /// <summary>
        /// Mã dịch vụ cho phòng
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.RoomServiceCode)]
        [Field(Length = 500)]
        public string RoomServiceID { get; set; }
        /// <summary>
        /// Tên dịch vụ cho phòng
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

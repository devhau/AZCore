using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        [Field(Length = 500)]
        public string RoomServiceID { get; set; }
        /// <summary>
        /// Tên dịch vụ cho phòng
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string RoomServiceName { get; set; }
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

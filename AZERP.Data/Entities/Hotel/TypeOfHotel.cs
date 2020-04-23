using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class TypeOfHotelService : EntityService<TypeOfHotelService, TypeOfHotelModel>, IAZTransient
    {
        public TypeOfHotelService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin các loại của nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel_typeofhotel")]
    public class TypeOfHotelModel : EntityModel<TypeOfHotelModel, long>
    {
        /// <summary>
        /// Mã loại phòng trọ
        /// </summary>
        [Field(Length = 500)]
        public string TypeOfHotelID { get; set; }
        /// <summary>
        /// Tên loại phòng trọ
        /// Ví dụ : 15m2, 25m2, 50m2, 100m2
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string TypeOfHotelName { get; set; }
        /// <summary>
        /// Tiền phòng
        /// </summary>
        [Field]
        public decimal RoomCharge { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

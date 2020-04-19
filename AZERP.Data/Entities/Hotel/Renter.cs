using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class RenterService : EntityService<RenterService, RenterModel>, IAZTransient
    {
        public RenterService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của người thuê nhà
    /// </summary>

    [TableInfo(TableName = "az_hotel_renter")]
    public class RenterModel : EntityModel<RenterModel, long>
    {
        /// <summary>
        /// Mã người thuê nhà
        /// </summary>
        [Field(Length = 500)]
        public string RenterID { get; set; }
        /// <summary>
        /// Tên người thuê nhà
        /// </summary>
        [Field(Length = 500)]
        public string RenterName { get; set; }
        /// <summary>
        /// Chứng minh nhân dân / Căn cước công dân
        /// </summary>
        [Field]
        public int CMND { get; set; }
        /// <summary>
        /// Số lượng người trong 1 phòng
        /// </summary>
        [Field]
        public int Quantity { get; set; }
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [Field(Length = 500)]
        public string HotelID { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

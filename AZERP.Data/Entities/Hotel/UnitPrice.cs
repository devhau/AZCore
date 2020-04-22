using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class UnitPriceService : EntityService<UnitPriceService, UnitPriceModel>, IAZTransient
    {
        public UnitPriceService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của các chi phí
    /// </summary>

    [TableInfo(TableName = "az_hotel_unitprice")]
    public class UnitPriceModel : EntityModel<UnitPriceModel, long>
    {
        /// <summary>
        /// Mã chi phí
        /// </summary>
        [Field(Length = 500)]
        public string UnitPriceID { get; set; }
        /// <summary>
        /// Tiền điện
        /// </summary>
        [Field]
        public decimal ElectricityCharge { get; set; }
        /// <summary>
        /// Tiền nước
        /// </summary>
        [Field]
        public decimal WaterCharge { get; set; }
        /// <summary>
        /// Tiền khác: tiền internet, tiền rác, ...
        /// </summary>
        [Field]
        public decimal ChargeOther { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

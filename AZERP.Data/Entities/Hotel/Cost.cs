using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class CostService : EntityService<CostService, CostModel>, IAZTransient
    {
        public CostService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của các chi phí
    /// </summary>

    [TableInfo(TableName = "az_hotel_cost")]
    public class CostModel : EntityModel<CostModel, long>
    {
        /// <summary>
        /// Mã chi phí
        /// </summary>
        [Field(Length = 500)]
        public string CostID { get; set; }
        /// <summary>
        /// Tiền điện
        /// </summary>
        [Field]
        public decimal ElectricityBill { get; set; }
        /// <summary>
        /// Tiền nước
        /// </summary>
        [Field]
        public decimal WaterBill { get; set; }
        /// <summary>
        /// Chi phí khác: tiền internet, tiền rác, ...
        /// </summary>
        [Field]
        public decimal CostOther { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

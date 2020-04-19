using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class BillService : EntityService<BillService, BillModel>, IAZTransient
    {
        public BillService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn
    /// </summary>

    [TableInfo(TableName = "az_hotel_bill")]
    public class BillModel : EntityModel<BillModel, long>
    {
        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        [Field(Length = 500)]
        public string BillID { get; set; }
        /// <summary>
        /// Tên hóa đơn
        /// ví dụ: tháng 3-2020
        /// </summary>
        [Field(Length = 500)]
        public string BillName { get; set; }
        /// <summary>
        /// Mã người thuê trọ
        /// </summary>
        [Field(Length = 500)]
        public string RenterID { get; set; }
        /// <summary>
        /// Mã chi phí
        /// </summary>
        [Field(Length = 500)]
        public string CostID { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

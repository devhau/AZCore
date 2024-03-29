﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class TotalBillService : EntityService< TotalBillModel>, IAZTransient
    {
        public TotalBillService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn tổng
    /// </summary>

    [TableInfo(TableName = "az_hotel_total_bill")]
    public class TotalBillModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Mã hóa đơn tổng
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.TotalBillCode)]
        [Field]
        public string TotalBillCode { get; set; }
        /// <summary>
        /// Tên hóa đơn
        /// ví dụ: tháng 3-2020
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string TotalBillName { get; set; }
        /// <summary>
        /// Mã đơn cố định
        /// </summary>
        [Field]
        public long FixedBillID { get; set; }
        /// <summary>
        /// Mã đơn lưu động
        /// </summary>
        [Field]
        public long ChangeBillID { get; set; }
        /// <summary>
        /// Tổng tiền
        /// </summary>
        [Field]
        public decimal TotalPricess { get; set; }
        /// <summary>
        /// Tiền nợ
        /// </summary>
        [Field]
        public decimal Debt { get; set; }
        /// <summary>
        /// Thời hạn nộp tiền
        /// </summary>
        [Field]
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [Field]
        public BillStatus? StatusBill { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

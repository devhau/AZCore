﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class PaymentService : EntityService<PaymentService, PaymentModel>, IAZTransient
    {
        public PaymentService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của thanh toán tiền
    /// </summary>

    [TableInfo(TableName = "az_hotel_payment")]
    public class PaymentModel : EntityModel<PaymentModel, long>
    {
        /// <summary>
        /// Mã thanh toán
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.PaymentCode)]
        [Field]
        public string PaymentCode { get; set; }
        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        [Field]
        public long TotalBillID { get; set; }
        /// <summary>
        /// Tiền thanh toán
        /// </summary>
        [Field]
        public decimal Pricess { get; set; }
        /// <summary>
        /// Ngày thanh toán
        /// </summary>
        [Field]
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

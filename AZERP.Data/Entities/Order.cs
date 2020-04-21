﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class OrderService : EntityService<OrderService, OrderModel>, IAZTransient
    {
        public OrderService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin hóa đơn nhập
    /// </summary>

    [TableInfo(TableName = "az_order")]
    public class OrderModel : EntityModel<OrderModel, long>
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Field]
        public long CustomerId { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [Field]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Nhân viên tạo đơn
        /// </summary>
        [Field]
        public long AccountId { get; set; }
        /// <summary>
        /// Nhân viên duyệt đơn
        /// </summary>
        [Field]
        public long ActivedAccountId { get; set; }
        /// <summary>
        /// Nhân viên hủy đơn
        /// </summary>
        [Field]
        public long CancelledAccountId { get; set; }
        /// <summary>
        /// Nhân viên kết thúc đơn
        /// </summary>
        [Field]
        public long ClosedAccountId { get; set; }
        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        [Field]
        public OrderPayment OrderPayment { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
        /// <summary>
        /// Ngày hoàn thành
        /// </summary>
        [Field]
        public DateTime CompleteOn { get; set; }
    }
}
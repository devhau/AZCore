﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class CustomersService : EntityService<CustomersService, CustomersModel>, IAZTransient
    {
        public CustomersService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>

    [TableInfo(TableName = "az_customers")]
    public class CustomersModel : EntityModel<CustomersModel, long>
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Họ Tên
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [Field]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [Field]
        public Gender? Gender { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 500)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Field(Length = 500)]
        public string Email { get; set; }
        /// <summary>
        /// Website
        /// </summary>
        [Field(Length = 500)]
        public string Website { get; set; }
        /// <summary>
        /// Địa chỉ giao hàng của khách
        /// </summary>
        [Field(Length = 1000)]
        public string Address { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
        /// <summary>
        /// Trạng thái khách hàng
        /// </summary>
        [Field]
        public CustomersStatus CustomersStatus { get; set; }
    }
}

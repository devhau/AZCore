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
    public class SupplierService : EntityService<SupplierService, SupplierModel>, IAZTransient
    {
        public SupplierService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin nhà cung cấp
    /// </summary>

    [TableInfo(TableName = "az_supplier")]
    public class SupplierModel : EntityModel<SupplierModel, long>
    {
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Tên viết tắt
        /// </summary>
        [Field(Length = 500)]
        public string AbbreviatedName { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 50)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Field(Length = 500)]
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Mô tả công ty
        /// </summary>
        [Field]
        public string Description { get; set; }
        /// <summary>
        /// Trạng thái hoạt động
        /// </summary>
        [Field]
        public bool SupplierStatus { get; set; }
    }
}

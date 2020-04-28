using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class StoreService : EntityService<StoreService, StoreModel>, IAZTransient
    {
        public StoreService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin kho
    /// </summary>

    [TableInfo(TableName = "az_store")]
    public class StoreModel : EntityModel<StoreModel, long>
    {
        /// <summary>
        /// Mã kho
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.StoreCode)]
        [Field(Length = 50)]
        public string Code { get; set; }
        /// <summary>
        /// Tên Kho
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
        /// Số điện thoại kho
        /// </summary>
        [Field(Length = 50)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Mô tả kho
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
    }
}

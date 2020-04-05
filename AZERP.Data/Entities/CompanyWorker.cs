using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class CompanyWorkerService : EntityService<CompanyWorkerService, CompanyWorkerModel>, IAZTransient
    {
        public CompanyWorkerService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin công ty thuê công nhân
    /// </summary>

    [TableInfo(TableName = "az_company_worker")]
    public class CompanyWorkerModel : EntityModel<CompanyWorkerModel, long>
    {
        /// <summary>
        /// Tên công ty
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
        /// Địa chỉ
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Công ty ở khu vực nào
        /// </summary>
        [Field]
        public EnumAddressWorker? AtAddress { get; set; }
        /// <summary>
        /// Mô tả công ty
        /// </summary>
        [Field]
        public string Description { get; set; }
    }
}

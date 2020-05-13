﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class RenterService : EntityService<RenterService, RenterModel>, IAZTransient
    {
        public RenterService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của người thuê nhà
    /// </summary>

    [TableInfo(TableName = "az_hotel_renter")]
    public class RenterModel : EntityModel<RenterModel, long>
    {
        /// <summary>
        /// Mã người thuê nhà
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.RenterCode)]
        [Field]
        public long RenterID { get; set; }
        /// <summary>
        /// Tên người thuê nhà
        /// </summary>
        [Field(Length = 500)]
        public string RenterName { get; set; }
        /// <summary>
        /// Địa chỉ (sổ khẩu thường trú)
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Chứng minh nhân dân / Căn cước công dân
        /// </summary>
        [Field]
        public int CMND { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 11)]
        public int Tel { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

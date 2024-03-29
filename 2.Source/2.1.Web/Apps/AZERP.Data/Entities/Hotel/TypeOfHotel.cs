﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class TypeOfHotelService : EntityService< TypeOfHotelModel>, IAZTransient
    {
        public TypeOfHotelService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin loại nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel_typeofhotel")]
    public class TypeOfHotelModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Tên loại phòng trọ
        /// Ví dụ : 15m2, 25m2, 50m2, 100m2
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string TypeOfHotelName { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}

using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class BuildingService : EntityService<BuildingService, BuildingModel>, IAZTransient
    {
        public BuildingService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Cộng tác viên
    /// </summary>

    [TableInfo(TableName = "az_building")]
    public class BuildingModel : EntityModel<BuildingModel, long>
    {
        /// <summary>
        /// Mã code
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Tên cộng tác viên
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        [Field]
        public string PhoneNumber { get; set; }
        [Field]
        public string Email { get; set; }
        [Field]
        public string Address { get; set; }

    }
}

using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobVina.Data.Entities.Location
{
    public class WardService : EntityService<WardModel>, IAZTransient
    {
        public WardService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Xã/Phường
    /// </summary>
    [TableInfo(TableName = "az_location_Ward")]
    public class WardModel : IEntity
    {
        [Field(IsKey =true)]
        public int Code { get; set; }
        [Field(Length = 255)]
        public string Name { get; set; }
        [Field(Length = 255)]
        public string Type { get; set; }
        [Field]
        public int DistrictCode { get; set; }
    }
   
}

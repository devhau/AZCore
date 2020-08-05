using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;

namespace JobVina.Data.Entities.Location
{
    public class IndustrialAreaService : EntityService<IndustrialAreaModel>, IAZTransient
    {
        public IndustrialAreaService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Khu công nghiệp ở việt nam
    /// </summary>
    [TableInfo(TableName = "az_location_industrial_area")]
    public class IndustrialAreaModel : IEntity
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        public int Code { get; set; }
        [Field(Length = 255)]
        public string Name { get; set; }
        [Field(Length = 255)]
        public string Type { get; set; }
        [Field]
        public int ProvinceCode { get; set; }
    }
}

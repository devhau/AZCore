using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;
using System.Threading.Tasks;

namespace JobVina.Data.Entities
{
    public class DistrictService : EntityService<DistrictService, DistrictModel>, IAZTransient
    {
        public DistrictService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Quận/Huyện
    /// </summary>
    [TableInfo(TableName = "az_location_district")]
    public class DistrictModel : IEntity
    {
        [Field(IsKey = true)]
        public int Code { get; set; }
        [Field(Length =255)]
        public string Name { get; set; }
        [Field(Length = 255)]
        public string Type { get; set; }
        [Field]
        public int ProvinceCode { get; set; }
    }
}

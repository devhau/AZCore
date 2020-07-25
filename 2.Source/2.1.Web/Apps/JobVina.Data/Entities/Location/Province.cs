using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;
using System.Threading.Tasks;

namespace JobVina.Data.Entities
{
    public class ProvinceService : EntityService<ProvinceService, ProvinceModel>, IAZTransient
    {
        public ProvinceService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thành phố
    /// </summary>
    [TableInfo(TableName = "az_location_province")]
    public class ProvinceModel : IEntity
    {
        [Field(IsKey = true)]
        public int Code { get; set; }
        [Field(Length = 255)]
        public string Name { get; set; }
        [Field]
        public string Type { get; set; }
    }
}

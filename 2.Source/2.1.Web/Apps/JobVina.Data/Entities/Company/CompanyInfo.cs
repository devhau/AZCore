using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;

namespace JobVina.Data.Entities.Company
{
    public class CompanyInfoService : EntityService<CompanyInfoModel>, IAZTransient
    {
        public CompanyInfoService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin công ty
    /// </summary>
    [TableInfo(TableName = "az_company_info")]
    public class CompanyInfoModel : IEntity
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        public int Code { get; set; }
        [Field(Length = 255)]
        public string Name { get; set; }
        [Field(Length = 255)]
        public int IndustrialAreaCode { get; set; }
        [Field]
        public string Address { get; set; }
        [Field]
        public string Job { get; set; }
        [Field]
        public string Note { get; set; }
    }
}

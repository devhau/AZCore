using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZCore.Identity;
using System.Linq;

namespace JobVina.Data.Entities
{
    public class TenantService : EntityService< TenantModel>, IAZTransient, ITenantService
	{
		public TenantService(IDatabaseCore databaseCore) : base(databaseCore)
		{
		}

        public ITenant GetTenantByCanonicalName(string name)
        {
            return this.Select(p => p.CanonicalName == name).FirstOrDefault();
        }

        public ITenant GetTenantById(long id)
        {
            return this.Select(p => p.Id == id).FirstOrDefault();
        }
    }
	public class TenantModel : AZTenant
	{
        [Field(Display ="Cho phép hiển thị trên trang chủ")]
        public bool IsShowHome { get; set; }
	}
}

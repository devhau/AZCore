using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;
using System.Linq;

namespace AZERP.Data.Entities
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
	}

}

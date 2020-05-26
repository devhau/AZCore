using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;
using System.Linq;

namespace AZERP.Data.Entities
{
	public class TenantService : EntityService<TenantService, TenantModel>, IAZTransient, ITenantService
	{
		public TenantService(IDbConnection _connection) : base(_connection)
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
	public class TenantModel : AZTenant<TenantModel>
	{
	}

}

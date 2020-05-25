using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
	public class TenantService : EntityService<TenantService, TenantModel>, IAZTransient
	{
		public TenantService(IDbConnection _connection) : base(_connection)
		{
		}
	}
	public class TenantModel : AZTenant<TenantModel>
	{
	}

}

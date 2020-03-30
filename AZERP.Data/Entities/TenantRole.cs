using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
    public class TenantRoleService : EntityService<TenantRoleService, TenantRoleModel>, IAZTransient
    {
        public TenantRoleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class TenantRoleModel : AZTenantRole<TenantRoleModel, long>
    {
    }
}

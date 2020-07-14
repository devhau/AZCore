using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class TenantRoleService : EntityService<TenantRoleService, TenantRoleModel>, IAZTransient
    {
        public TenantRoleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class TenantRoleModel : AZTenantRole<TenantRoleModel>
    {
    }
}

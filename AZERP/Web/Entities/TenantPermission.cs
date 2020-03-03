using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZ.Web.Entities
{
    public class TenantPermissionService : EntityService<TenantPermissionService, TenantPermissionModel>, IAZTransient
    {
        public TenantPermissionService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class TenantPermissionModel : AZTenantPermission<TenantPermissionModel, long>
    {
    }
}

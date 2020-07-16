using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
    public class TenantPermissionService : EntityService<TenantPermissionService, TenantPermissionModel>, IAZTransient
    {
        public TenantPermissionService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class TenantPermissionModel : AZTenantPermission<TenantPermissionModel>
    {
    }
}

using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class TenantPermissionService : EntityService< TenantPermissionModel>, IAZTransient
    {
        public TenantPermissionService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class TenantPermissionModel : AZTenantPermission
    {
    }
}

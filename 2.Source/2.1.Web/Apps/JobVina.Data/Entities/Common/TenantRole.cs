using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class TenantRoleService : EntityService< TenantRoleModel>, IAZTransient
    {
        public TenantRoleService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class TenantRoleModel : AZTenantRole
    {
    }
}

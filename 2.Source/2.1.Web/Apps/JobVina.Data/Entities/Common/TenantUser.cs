using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;

namespace JobVina.Data.Entities
{
    public class TenantUserService : EntityService< TenantUserModel>, IAZTransient
    {
        public TenantUserService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class TenantUserModel : AZTenantUser
    {
    }
    
}

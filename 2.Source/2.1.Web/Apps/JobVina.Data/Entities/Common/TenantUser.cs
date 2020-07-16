using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class TenantUserService : EntityService<TenantUserService, TenantUserModel>, IAZTransient
    {
        public TenantUserService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class TenantUserModel : AZTenantUser<TenantUserModel>
    {
    }
    
}

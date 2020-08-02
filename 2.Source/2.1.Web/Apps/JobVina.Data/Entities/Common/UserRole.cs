using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class UserRoleService : EntityService< UserRoleModel>, IAZTransient
    {
        public UserRoleService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class UserRoleModel : AZUserRole
    {
    }
}

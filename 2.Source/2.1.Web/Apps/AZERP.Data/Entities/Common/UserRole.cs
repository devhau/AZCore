using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
    public class UserRoleService : EntityService<UserRoleService, UserRoleModel>, IAZTransient
    {
        public UserRoleService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class UserRoleModel : AZUserRole<UserRoleModel>
    {
    }
}

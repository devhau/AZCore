using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
    public class UserPermissionService : EntityService<UserPermissionService, UserPermissionModel>, IAZTransient
    {
        public UserPermissionService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class UserPermissionModel : AZUserPermission<UserPermissionModel, long>
    {
    }
}

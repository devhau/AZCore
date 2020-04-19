using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZCore.Test
{
    public class UserPermissionService : EntityService<UserPermissionService, UserPermissionModel>, IAZTransient
    {
        public UserPermissionService(IDbConnection _connection) : base(_connection)
        {
        }
        public void DeleteByUserIdPermissionId(long UserId,long PermissionId) { 
        
            
        }
    }
    public class UserPermissionModel : AZUserPermission<UserPermissionModel>
    {
    }
}

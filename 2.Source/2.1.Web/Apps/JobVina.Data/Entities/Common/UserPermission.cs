using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class UserPermissionService : EntityService< UserPermissionModel>, IAZTransient
    {
        public UserPermissionService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
        public void DeleteByUserIdPermissionId(long UserId,long PermissionId) { 
        
            
        }
    }
    public class UserPermissionModel : AZUserPermission
    {
    }
}

using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZ.Web.Entities
{
    public class RolePermissionService : EntityService<RolePermissionService, RolePermissionModel>, IAZTransient
    {
        public RolePermissionService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class RolePermissionModel : AZRolePermission<RolePermissionModel, long>
    {
    }
}

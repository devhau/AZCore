using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Collections.Generic;
using System.Data;

namespace JobVina.Data.Entities
{
    public class RolePermissionService : EntityService<RolePermissionService, RolePermissionModel>, IAZTransient
    {
        public RolePermissionService(IDbConnection _connection) : base(_connection)
        {
        }
        public List<string> GetPermissionByRoleId(long roleId) {

            return null;
        }
    }
    public class RolePermissionModel : AZRolePermission<RolePermissionModel>
    {
    }
}

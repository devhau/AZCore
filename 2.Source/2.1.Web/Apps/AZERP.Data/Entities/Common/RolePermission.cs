using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Collections.Generic;
using System.Data;

namespace AZERP.Data.Entities
{
    public class RolePermissionService : EntityService<RolePermissionService, RolePermissionModel>, IAZTransient
    {
        public RolePermissionService(IDatabaseCore databaseCore) : base(databaseCore)
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

using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class PermissionService : EntityService<PermissionService, PermissionModel>, IAZTransient
    {
        public PermissionService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class PermissionModel : AZPermission<PermissionModel, long>
    {
    }
}

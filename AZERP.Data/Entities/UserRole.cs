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
    public class UserRoleService : EntityService<UserRoleService, UserRoleModel>, IAZTransient
    {
        public UserRoleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class UserRoleModel : AZUserRole<UserRoleModel, long>
    {
    }
}

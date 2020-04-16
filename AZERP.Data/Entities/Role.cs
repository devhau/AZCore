using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace AZERP.Data.Entities
{
    public class RoleService : EntityService<RoleService, RoleModel>, IAZTransient
    {
        public RoleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class RoleModel : AZRole<RoleModel>
    {
    }
}

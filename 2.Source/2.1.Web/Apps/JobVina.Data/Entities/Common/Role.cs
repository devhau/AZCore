using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;

namespace JobVina.Data.Entities
{
    public class RoleService : EntityService< RoleModel>, IAZTransient
    {
        public RoleService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    public class RoleModel : AZRole
    {
    }
}

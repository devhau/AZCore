using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Data;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class PermissionService : EntityService<PermissionService, PermissionModel>, IAZTransient
    {
        public PermissionService(IDbConnection _connection) : base(_connection)
        {
        }
        public async Task<int> DeleteAll() {
          return await this.ExecuteAsync(buildSQL.SQLDelete());        
        }
    }
    public class PermissionModel : AZPermission<PermissionModel, long>
    {
    }
}

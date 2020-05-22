using AZCore.Database;
using AZCore.Database.Attributes;
using System.Collections.Generic;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_permission")]
    public class AZPermission<TEntity> : IEntity
    {
        [Field]
        public string KeyName { get; set; }
        [Field(IsKey =true,Length =50)]
        public string Code { get; set; }
        [Field(Length =128)]
        public string Name { get; set; }
    }
    public interface IPermissionService {
        IEnumerable<string> GetPermissionByUserId(long UserId);
    }
}

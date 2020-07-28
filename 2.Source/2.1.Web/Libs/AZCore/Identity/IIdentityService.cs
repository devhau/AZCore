using System.Collections.Generic;

namespace AZCore.Identity
{
    public interface IIdentityService
    {
        IEnumerable<string> GetPermissionByUserId(long UserId);
        long GetTenantByUserId(long UserId);
    }
}

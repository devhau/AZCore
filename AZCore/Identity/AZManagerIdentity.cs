using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Identity
{
    public class AZManagerIdentity<TUser,TRole,TPermission,TTenant,TKey>
            where TUser:AZUser<TUser, TKey>
            where TRole:AZRole<TRole,TKey>
            where TPermission:AZPermission<TPermission,TKey>
            where TTenant:AZTenant<TTenant,TKey>
    {
        public AZManagerIdentity(TUser user,TRole role,TPermission permission,TTenant tenant) { 
        
        }
    }
    public class AZManagerIdentity<TUser, TRole, TPermission, TKey>
            where TUser : AZUser<TUser, TKey>
            where TRole : AZRole<TRole,TKey>
            where TPermission : AZPermission<TPermission,TKey>
    {
        public AZManagerIdentity(TUser user, TRole role, TPermission permission)
        {

        }
    }
}

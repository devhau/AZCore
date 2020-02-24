using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZWeb.Identity
{
    public class AZUserStore<TUser,TRole,TPermission,TTenant,TKey>
            where TUser:AZUser<TUser, TKey>
            where TRole:AZRole<TRole,TKey>
            where TPermission:AZPermission<TPermission,TKey>
            where TTenant:AZTenant<TTenant,TKey>
    {
        public AZUserStore(TUser user,TRole role,TPermission permission,TTenant tenant) { 
        
        }
    }
    public class AZUserStore<TUser, TRole, TPermission, TKey>
            where TUser : AZUser<TUser, TKey>
            where TRole : AZRole<TRole,TKey>
            where TPermission : AZPermission<TPermission,TKey>
    {
        
        public AZUserStore(TUser user, TRole role, TPermission permission)
        {

        }

    }
}

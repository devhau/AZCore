using AZERP.Data.Entities;
using System.Collections.Generic;

namespace AZERP.Web.Modules.Common.Permission
{
    public class ViewPermission
    {
        public List<PermissionModel> Permissions;
        public List<string> PermissionActive;
        public string CheckItem(PermissionModel item, PermissionModel itemParrent=null) {
            if (itemParrent!=null&&PermissionActive != null && !PermissionActive.Contains(itemParrent.Code))
            {
                return " disabled ";
            }
            if (PermissionActive != null && PermissionActive.Contains(item.Code)) {
                return " checked ";
            }
            return "";
        }
      
    }
}

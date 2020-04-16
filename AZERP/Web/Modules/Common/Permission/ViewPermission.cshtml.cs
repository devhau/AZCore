using AZERP.Data.Entities;
using System;
using System.Collections.Generic;

namespace AZERP.Web.Modules.Common.Permission
{
    public class ViewPermission
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public object Value { get; set; }
        public List<PermissionModel> Permissions;
        public List<string> PermissionActive;
        public string CheckItem(PermissionModel item) {
            if (PermissionActive != null && PermissionActive.IndexOf(item.Code) >= 0) {
                return " checked ";
            }
            return "";
        }
      
    }
}

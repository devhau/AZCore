using System.Collections.Generic;

namespace AZCore.Identity
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> PermissionActive { get; set; }
        public virtual bool HasPermission(string PermissonCode) {
            return string.IsNullOrEmpty(PermissonCode)|| (this.PermissionActive != null && this.PermissionActive.IndexOf(PermissonCode)>=0);
        }
    }
}

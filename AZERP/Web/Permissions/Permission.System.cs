using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Thiết lập hệ thống
        /// </summary>
        [Field(Display = "Thiết lập hệ thống",OrderIndex =0)]
        public const string System = "10001";
       
    }
}

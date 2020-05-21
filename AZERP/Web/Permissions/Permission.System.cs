using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Thiết lập hệ thống
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,  Display = "Thiết lập hệ thống",OrderIndex =0)]
        public const string System = "6B4DE0CF-E64C-4C55-88F1-940D854A6019";

    }
}

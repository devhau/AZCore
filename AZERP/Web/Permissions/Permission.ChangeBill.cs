using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý Area
       /// </summary>
        [Field(Display = "Quản lý Area", OrderIndex = 5)]
        public const string ChangeBill = "10006";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 5)]
        public const string ChangeBill_Add = "10006001";
        /// <summary>
        /// Quyền chỉnh sửa Area
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 5)]
        public const string ChangeBill_Edit = "10006002";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 5)]
        public const string ChangeBill_Remove = "10006003";
        /// <summary>
        /// Quyền xuất excel danh sách Area
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 5)]
        public const string ChangeBill_Export = "10006004";
        /// <summary>
        /// Quyền nhập excel danh sách Area
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 5)]
        public const string ChangeBill_Import = "10006005";
    }
}

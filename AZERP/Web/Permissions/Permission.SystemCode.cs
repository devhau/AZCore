using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý System Code
        /// </summary>
        [Field(Display = "Quản lý System Code", OrderIndex = 2)]
        public const string SystemCode = "10008";
        /// <summary>
        /// Quyền thêm mới SystemCode
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 2)]
        public const string SystemCode_Add = "10008001";
        /// <summary>
        /// Quyền chỉnh sửa SystemCode
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 2)]
        public const string SystemCode_Edit = "10008002";
        /// <summary>
        /// Quyền thêm mới SystemCode
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 2)]
        public const string SystemCode_Remove = "10008003";
        /// <summary>
        /// Quyền xuất excel danh sách SystemCode
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 2)]
        public const string SystemCode_Export = "10008004";
        /// <summary>
        /// Quyền nhập excel danh sách SystemCode
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 2)]
        public const string SystemCode_Import = "10008005";
    }
}

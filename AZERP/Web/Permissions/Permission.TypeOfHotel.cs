using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý TypeOfHotel
       /// </summary>
        [Field(Display = "Quản lý TypeOfHotel", OrderIndex = 6)]
        public const string TypeOfHotel = "10006";
        /// <summary>
        /// Quyền thêm mới TypeOfHotel
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 6)]
        public const string TypeOfHotel_Add = "10006001";
        /// <summary>
        /// Quyền chỉnh sửa TypeOfHotel
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 6)]
        public const string TypeOfHotel_Edit = "10006002";
        /// <summary>
        /// Quyền thêm mới TypeOfHotel
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 6)]
        public const string TypeOfHotel_Remove = "10006003";
        /// <summary>
        /// Quyền xuất excel danh sách TypeOfHotel
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 6)]
        public const string TypeOfHotel_Export = "10006004";
        /// <summary>
        /// Quyền nhập excel danh sách TypeOfHotel
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 6)]
        public const string TypeOfHotel_Import = "10006005";
    }
}

using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    { /// <summary>
      /// Quyền quản lý Cus
      /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Quản lý khách hàng", OrderIndex = 1)]
        public const string Cus = "33b5dfbc-6f84-42b6-9485-268046b6e6b5";
        /// <summary>
        /// Quyền thêm mới Cus
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Thêm mới", OrderIndex = 1)]
        public const string Cus_Add = "60f6a331-d7c4-4f95-aa15-ab8f407f977b";
        /// <summary>
        /// Quyền chỉnh sửa Cus
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Sửa", OrderIndex = 1)]
        public const string Cus_Edit = "9985518f-87dc-4a98-9bce-a2143fddcd24";
        /// <summary>
        /// Quyền thêm mới Cus
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xóa", OrderIndex = 1)]
        public const string Cus_Remove = "68485099-6aa2-4340-8c58-8140c118965c";
        /// <summary>
        /// Quyền xuất excel danh sách Cus
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xuất excel", OrderIndex = 1)]
        public const string Cus_Export = "d62157b6-f277-477a-84ca-3b7608833ced";
        /// <summary>
        /// Quyền nhập excel danh sách Cus
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Nhập excel", OrderIndex = 1)]
        public const string Cus_Import = "b16734d4-2fca-4af5-aef2-ccd59ca6904d";
    }
}

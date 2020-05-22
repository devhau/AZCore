using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý Area
       /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Quản lý Area", OrderIndex = 5)]
        public const string Area = "a248fa18-96e5-4916-a601-1faa9ee4ca9c";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Thêm mới", OrderIndex = 5)]
        public const string Area_Add = "87733f29-5d76-4cc2-a9a9-6e237899b6bf";
        /// <summary>
        /// Quyền chỉnh sửa Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Sửa", OrderIndex = 5)]
        public const string Area_Edit = "4aeb4a97-89b7-4aa6-8f14-6582aef200db";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xóa", OrderIndex = 5)]
        public const string Area_Remove = "1423f365-6854-4a57-bcb7-16b12715c4d9";
        /// <summary>
        /// Quyền xuất excel danh sách Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xuất excel", OrderIndex = 5)]
        public const string Area_Export = "f31d3c62-a034-42da-bd2e-94312b08bd81";
        /// <summary>
        /// Quyền nhập excel danh sách Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Nhập excel", OrderIndex = 5)]
        public const string Area_Import = "8eebaae5-3802-4d22-9205-1cd1dad2ef1c";
    }
}

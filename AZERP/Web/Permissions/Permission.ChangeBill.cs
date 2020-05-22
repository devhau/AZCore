using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý Area
       /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Quản lý Area", OrderIndex = 5)]
        public const string ChangeBill = "b6141899-49ea-4b6e-ae8d-adf689d6792a";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Thêm mới", OrderIndex = 5)]
        public const string ChangeBill_Add = "e3d434af-d965-4ed9-96d1-db145144f802";
        /// <summary>
        /// Quyền chỉnh sửa Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Sửa", OrderIndex = 5)]
        public const string ChangeBill_Edit = "5b395200-2020-494c-b2b5-d152fc503662";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xóa", OrderIndex = 5)]
        public const string ChangeBill_Remove = "cee90f3a-9691-4926-bfc3-a983803f9eca";
        /// <summary>
        /// Quyền xuất excel danh sách Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xuất excel", OrderIndex = 5)]
        public const string ChangeBill_Export = "5433ddc1-cb66-4e7e-bd52-a8c71991fbf1";
        /// <summary>
        /// Quyền nhập excel danh sách Area
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Nhập excel", OrderIndex = 5)]
        public const string ChangeBill_Import = "bb0aa0d5-068e-4b48-a2b0-fa8f9932d718";
    }
}

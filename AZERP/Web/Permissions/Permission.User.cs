using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    { /// <summary>
      /// Quyền quản lý User
      /// </summary>
        [Field(Display = "Quản lý User")]
        public const string User = "10002";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(Display = "Thêm mới User")]
        public const string User_Add = "10002001";
        /// <summary>
        /// Quyền chỉnh sửa User
        /// </summary>
        [Field(Display = "Chỉ sửa User")]
        public const string User_Edit = "10002002";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(Display = "Xóa User")]
        public const string User_Remove = "10002003";
        /// <summary>
        /// Quyền xuất excel danh sách User
        /// </summary>
        [Field(Display = "Export User")]
        public const string User_Export = "10002004";
        /// <summary>
        /// Quyền nhập excel danh sách User
        /// </summary>
        [Field(Display = "Import User")]
        public const string User_Import = "10002005";
    }
}

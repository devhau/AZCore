using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.User
{
    [TableColumn(Title ="Họ Tên",FieldName = "FullName",Width =150)]
    [TableColumn(Title = "Email", FieldName = "Email", Width = 100)]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = 150)]
    [TableColumn(Title = "Trạng thái", FieldName = "Status" ,DataType =typeof(EntityStatus))]
    [TableColumn(Title ="Đổi mật khẩu",LinkFormat = "/tai-khoan/doi-mat-khau.az?UserId={Id}", Text ="Đổi mật khẩu",Display =AZWeb.Module.Enums.DisplayColumn.IconText,Icon ="fas fa-key",Popup =AZWeb.Module.Enums.PopupSize.Popup,Permisson =Permissions.Permission.User_ChangePassword)]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    [ModulePermission(ViewCode = Permissions.Permission.User,AddCode = Permissions.Permission.User_Add, EditCode = Permissions.Permission.User_Edit, ExportCode = Permissions.Permission.User_Export, ImportCode = Permissions.Permission.User_Import, RemoveCode = Permissions.Permission.User_Remove)]
    public class FormUser : ManageModule<UserService, UserModel, FormUpdateUser>
    {
        public FormUser(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý tài khoản";
        }
    }
}

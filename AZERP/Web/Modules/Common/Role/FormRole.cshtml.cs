using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.Role
{
    [TableColumn(Title = "Vai trò", FieldName = "Name")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150, DataType = typeof(EntityStatus))]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    [ModulePermission(
        ViewCode =Permissions.Permission.Role,
        AddCode =Permissions.Permission.Role_Add,
        EditCode =Permissions.Permission.Role_Edit,
        ExportCode = Permissions.Permission.Role_Export,
        ImportCode = Permissions.Permission.Role_Import,
        RemoveCode = Permissions.Permission.Role_Remove
        )]
    public class FormRole : ManageModule<RoleService, RoleModel, FormUpdateRole>
    {
        public FormRole(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý vai trò";
        }
    }
}

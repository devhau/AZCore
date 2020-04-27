using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.SystemCode
{
    [TableColumn(Title = "Key", FieldName = "Key", DataType = typeof(Data.Enums.SystemCode))]
    [TableColumn(Title = "Tiên tố", FieldName = "Prefix")]
    [TableColumn(Title = "Chiều dài", FieldName = "Len")]
    [TableColumn(Title = "Mã hiện tại", FieldName = "GenCode")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150, DataType = typeof(EntityStatus))]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    [ModuleInfo(
        Title = "Quản lý mã hệ thống",
        ViewCode =Permissions.Permission.SystemCode,
        AddCode =Permissions.Permission.SystemCode_Add,
        EditCode =Permissions.Permission.SystemCode_Edit,
        ExportCode = Permissions.Permission.SystemCode_Export,
        ImportCode = Permissions.Permission.SystemCode_Import,
        RemoveCode = Permissions.Permission.SystemCode_Remove
        )]
    public class FormSystemCode : ManageModule<SystemCodeService, SystemCodeModel, FormUpdateSystemCode>
    {
        public FormSystemCode(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}

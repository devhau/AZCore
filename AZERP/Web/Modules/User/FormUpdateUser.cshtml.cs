using AZ.Web.Entities;
using AZCore.Database.Attr;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.User
{
    [TableColumn(Title = "Họ Tên", FieldName = "FullName", Width = "150px")]
    [TableColumn(Title = "Email", FieldName = "Email", Width = "100px")]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = "150px")]
    [TableColumn(Title = "Ghi chú", FieldName = "", Width = "")]
    public class FormUpdateUser : UpdateModule<UserService, UserModel>
    {
        public FormUpdateUser(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
            this.IsTheme = true;
        }

    }
}

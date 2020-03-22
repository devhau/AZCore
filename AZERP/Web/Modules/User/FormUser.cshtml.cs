using AZ.Web.Entities;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.User
{
    [TableColumn(Title ="Họ Tên",FieldName = "FullName",Width ="150px")]
    [TableColumn(Title = "Email", FieldName = "Email", Width = "100px")]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = "150px")]
    [TableColumn(Title = "Trạng thái", FieldName = "IsActive", Width = "")]
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

using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.User
{
    [TableColumn(Title ="Họ Tên",FieldName = "FullName",Width =150)]
    [TableColumn(Title = "Email", FieldName = "Email", Width = 100)]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = 150)]
    [TableColumn(Title = "Trạng thái", FieldName = "Status" ,DataType =typeof(EntityStatus))]
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

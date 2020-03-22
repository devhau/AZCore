using AZ.Web.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.User
{
    public class FormUpdateUser : UpdateModule<UserService, UserModel>
    {
        public FormUpdateUser(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public override void DataFormToData(UserModel DataForm)
        {
            if (DataForm.Password == "" || DataForm.Password == null)
            {
                this.httpContext.Request.Form.Keys.Remove("Password");
            }
            else {

                
            }
            base.DataFormToData(DataForm);
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
            this.IsTheme = true;
        }

    }
}

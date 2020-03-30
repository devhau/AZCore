using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;

namespace AZERP.Web.Modules.User
{
    public class FormUpdateUser : UpdateModule<UserService, UserModel>
    {
        public FormUpdateUser(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public override void DataFormToData(UserModel DataForm, Func<PropertyInfo, bool> funProper)
        {
            if (!DataForm.Password.IsNullOrEmpty())
            {
                if (this.Data == null)
                {
                    var pas = DataForm.Password;
                    DataForm.SetPassword(pas);
                }else if (this.Data != null&& DataForm.Password!= this.Data.Password) {
                    this.Data.SetPassword(DataForm.Password);
                }               
            }
            funProper = (item) => item.Name != "Password";
            base.DataFormToData(DataForm, funProper);
        }
        protected override void IntData()
        {
            this.Title = "Nhân viên";
            this.IsTheme = true;
        }

    }
}

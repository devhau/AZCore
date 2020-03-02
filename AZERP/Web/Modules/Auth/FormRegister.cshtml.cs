using AZ.Web.Entities;
using AZCore.Utility;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace AZ.Web.Modules.Auth
{
    public class FormRegister : ModuleBase
    {
        public class ViewModelRegister {
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string RePassword { get; set; }
        }
        User user;
        public FormRegister(IHttpContextAccessor httpContext, User _user) : base(httpContext)
        {
            this.user = _user;          
        }
        protected override void IntData()
        {
            this.Title = "Đăng ký tài khoản";
            this.IsTheme = false;

            this.HtmlResult.DoResult((mdo) =>
            {
                if (!httpContext.IsAjax() && PagesConfig != null)
                {
                    if (PagesConfig.Head != null)
                    {
                        mdo.CSS.InsertRange(0, PagesConfig.Head.Stypes);
                        mdo.JS.InsertRange(0, PagesConfig.Head.Scripts);
                    }
                }
            });
        }
        public IViewResult Get() {
            return View();
        }
        public IViewResult Post(string Fullname, string Email, string Password, string RePassword,string Phone)
        {
            user.FullName = Fullname;
            user.Email = Email;
            user.Salt= HashPassword.CreateSalt();
            user.Password = HashPassword.Create(Password, user.Salt);
            user.PhoneNumber = Phone;
            user.CreateAt = DateTime.Now;
            user.Insert().Wait();
            return View();
        }
    }
}

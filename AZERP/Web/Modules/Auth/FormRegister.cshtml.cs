using AZ.Web.Entities;
using AZCore.Utility;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace AZ.Web.Modules.Auth
{
    public class FormRegister : PageModule
    {
        UserService userService;
        public FormRegister(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Đăng ký tài khoản";
            this.IsTheme = false;

            this.DoView((mdo) =>
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
        public IView Get() {
            return View();
        }
        public IView Post(string Fullname, string Email, string Password, string RePassword, string Phone)
        {
            var user = new UserModel()
            {
                FullName = Fullname,
                Email = Email,
                PhoneNumber = Phone,
                CreateAt = DateTime.Now
            };
            user.SetPassword(Password);
            this.userService.Insert(user);
            this.AddMessage("Đăng ký thành công");
            return View();
        } 
    }
}

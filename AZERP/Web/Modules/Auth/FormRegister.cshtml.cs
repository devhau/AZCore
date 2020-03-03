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
        UserService userService;
        public FormRegister(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
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
        public IViewResult Post(string Fullname, string Email, string Password, string RePassword, string Phone)
        {
            var salt = HashPassword.CreateSalt();
            this.userService.Insert(new UserModel()
            {
                FullName = Fullname,
                Email = Email,
                Salt = salt,
                Password = HashPassword.Create(Password, salt),
                PhoneNumber = Phone,
                CreateAt = DateTime.Now
            });
            this.AddMessage("Đăng ký thành công");
            return View();
        } 
    }
}

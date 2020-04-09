using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Auth
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
            //this.AddMessage("Đăng ký thành công");
            return View();
        } 
    }
}

using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Common.Auth
{
    public class FormRegister : PageModule
    {
        public string Error { get; set; }
        UserService userService;
        public FormRegister(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Đăng ký tài khoản";
            this.LayoutTheme = "Fullscreen";
        }
        public IView Get() {
            return View();
        }
        public IView Post(string Fullname, string Email, string Password, string Phone)
        {
            if (this.userService.ExecuteNoneQuery(p => { p.AddWhere("Email", Email); p.SetColumn("count(0)"); }) > 0) {
                Error = "Email đã được người khác đăng ký rồi!";
                return View();
            }
            if (this.userService.ExecuteNoneQuery(p => { p.AddWhere("PhoneNumber", Phone); p.SetColumn("count(0)"); }) > 0)
            {
                Error = "Số điện thoại đã được người khác đăng ký rồi!";
                return View();
            }
            var user = new UserModel()
            {
                FullName = Fullname,
                Email = Email,
                PhoneNumber = Phone,
                Status = AZCore.Database.EntityStatus.Active,
                CreateAt = DateTime.Now
            };
            user.SetPassword(Password);
            this.userService.Insert(user);
            return GoToHome();
        } 
    }
}

using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace JobVina.Web.Modules.Auth
{
    public class FormRegister : PageHome
    {
        public string MessageError { get; set; }
        [BindService]
        public UserService userService;
        public FormRegister(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.IsTheme = false;
        }

        public IView Get()
        {
            return View();
        }
        public IView Post([BindForm]string InputFullName, [BindForm] string InputPhoneNumber, [BindForm] string InputPassword, [BindForm] string terms)
        {
            if (InputFullName.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập họ tên";
                return View();
            }
            if (InputPhoneNumber.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập số điện thoại"; 
                return View();
            }
            if (InputPassword.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập mật khẩu"; 
                return View();
            }

            var user = new UserModel()
            {
                FullName= InputFullName,
                PhoneNumber=InputPhoneNumber,
                Password=InputPassword
            };
            user.SetPassword(user.Password);
            user.CreateAt = DateTime.Now;
            user.CreateBy = 0;
            user.IsTenant = false;
            user.Status = AZCore.Database.EntityStatus.Active;
            userService.Insert(user);
            return GoToAuth(false);
        }
    }
}

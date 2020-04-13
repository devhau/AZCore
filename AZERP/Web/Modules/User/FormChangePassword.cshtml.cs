using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.User
{
    [Auth]
    public class FormChangePassword : PageModule
    {
        [BindQuery]
        public long? UserId { get; set; }
        UserService userService;
        public FormChangePassword(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Đổi mật khẩu";
            base.IntData();
        }
        public IView Get() {
            if (!IsAuth) {
                return GoToRedirect("/tai-khoan.az");
            }
            if (this.UserId == null) {
                this.UserId = this.User.Id;
            }
            return View();
        }
        public IView Post(string pass,long id)
        {
           var user= userService.GetById(id);
            user.SetPassword(pass);
            userService.Update(user);
            return Json("Đổi mật khẩu thành công");
        }

    }
}

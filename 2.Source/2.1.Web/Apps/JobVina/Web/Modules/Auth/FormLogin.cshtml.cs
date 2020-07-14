using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace JobVina.Web.Modules.Auth
{
    public class FormLogin : PageHome
    {
        public string MessageError { get; set; }
        [BindService]
        public UserService userService;
        public FormLogin(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.IsTheme = false;
        }

        public IView Get()
        {
            return View();
        }
        public async Task<IView> Post([BindForm]string InputPhoneNumberOrEmail, [BindForm] string InputPassword, [BindForm] bool CheckRemember,[BindQuery(FromName = "ref")]string linkRef)
        {
            var usr = this.userService.GetEmailOrUsernameOrPhoneNumber(InputPhoneNumberOrEmail);
            if (usr != null)
            {
                if (usr.HasPassword(InputPassword))
                {
                    if (usr.Status == AZCore.Database.EntityStatus.NoActive || usr.Status == null)
                    {

                        MessageError = "Tài khoản chưa được kích hoạt";
                        return View();
                    }
                    if (usr.Status == AZCore.Database.EntityStatus.Block)
                    {
                        MessageError = "Tài khoản đã bị khóa";
                        return View();
                    }

                    var ulogin = usr.CopyTo<UserInfo>();
                    await this.LoginAsync(ulogin, CheckRemember);

                    return linkRef.IsNullOrEmpty() ? this.GoToHome() : this.GoToRedirect(linkRef.UrlDecode());
                }
            }
            MessageError = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}

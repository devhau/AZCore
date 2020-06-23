using AZCore.Extensions;
using AZCore.Identity;
using AZERP.Data.Entities;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Modules.Common.Auth
{
    public class FormLogin:PageModule
    {
        public string Error { get; set; }
        [BindService]
        public UserService userService;
        [BindService]
        public TenantUserService tenantUserService;
        public FormLogin(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Đăng nhập hệ thống";
            this.LayoutTheme = "Fullscreen";
        }

        public IView Get()
        {
            if (this.HttpContext.IsSubdomain() && this.Tenant == null) 
            {
                return View("StoreNotFound");
            }
            if (this.Tenant == null) {
                return View("LoginStore");
            }
            return View();
        }
        public async Task<IView> GetLogout() {
            await this.LogoutAsync();
            return GoToHome();
        }
        public IView PostStore([BindForm] string subdomain) {
            return GoToRedirect(string.Format("https://{0}.{1}", subdomain, this.HttpContext.Request.Host.Value));
        }
        [BindQuery(FromName = "ref")]
        public string UrlRef { get; set; }
        public async  Task<IView> Post([BindForm]string azemail, [BindForm]string azpassword, [BindForm]bool azremember) {
            var usr = this.userService.GetEmailOrUsername(azemail);
            if (usr != null) {
                if (usr.HasPassword(azpassword))      
                {
                    if (usr.Status == AZCore.Database.EntityStatus.NoActive|| usr.Status == null) {

                        Error = "Tài khoản chưa được kích hoạt";
                        return View();
                    }
                    if (usr.Status == AZCore.Database.EntityStatus.Block)
                    {
                        Error = "Tài khoản đã bị khóa";
                        return View();
                    }
                    
                    if (tenantUserService.Select(p => p.TenantId == this.TenantId && p.UserId == usr.Id && p.Status == TenantUserStatus.Active).Count()!=1) {
                        Error = "Tài khoản chưa đăng ký với cửa hàng hoặc bị khóa";
                        return View();
                    }
                    var ulogin = usr.CopyTo<UserInfo>();
                    await this.LoginAsync(ulogin, azremember);
                    
                    return UrlRef.IsNullOrEmpty()? this.GoToHome():this.GoToRedirect(this.UrlRef.UrlDecode());
                }
            }
            Error = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}

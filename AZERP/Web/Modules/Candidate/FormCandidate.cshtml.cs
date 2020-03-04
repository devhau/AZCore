using AZ.Web.Entities;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Candidate
{
    public class FormCandidate: ModuleBase
    {
        UserService userService;
        public FormCandidate(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        
        }

        public  IViewResult Get(object[] Id)
        {
            return View();
        }
       
    }
}

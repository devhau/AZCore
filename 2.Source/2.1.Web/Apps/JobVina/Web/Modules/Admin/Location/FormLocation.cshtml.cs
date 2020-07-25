using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Location
{
    public class FormLocation : PageManage<UserService,UserModel, UpdateLocation>
    {
        public FormLocation(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách công ty";
        }
    }
}

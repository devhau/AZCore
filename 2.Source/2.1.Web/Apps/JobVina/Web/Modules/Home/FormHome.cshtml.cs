using AZCore.Database;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home
{
    public class FormHome : PageHome
    {
        public FormHome(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.Title = "JobVINA";
            return View();
        }
        public IView GetCreateDatabase() {
            new DBCreateEntities(HttpContext.RequestServices.GetService(typeof(IDatabaseCore)) as IDatabaseCore).CheckEmptyAndCreateDatabase();
            return Json("Tạo database thành công");
        }
    }
}

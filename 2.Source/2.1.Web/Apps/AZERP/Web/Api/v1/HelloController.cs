using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Api.v1
{
    public class HelloController : ApiController
    {
        public HelloController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView GetIndex() {
            return Json("Xin Chào");
        }
    }
}

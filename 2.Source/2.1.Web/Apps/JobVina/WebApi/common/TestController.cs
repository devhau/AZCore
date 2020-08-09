using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.WebApi.common
{
    public class TestController : ApiController
    {
        public TestController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView GetIndex() {
            return Json("Xin chào mọi người");
        }
    }
}

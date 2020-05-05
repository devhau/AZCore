using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ApiController : ModuleBase
    {
        public ApiController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
}

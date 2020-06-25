
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Api.v1.Common
{
    public class AuthController : ApiController
    {
        public AuthController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
}

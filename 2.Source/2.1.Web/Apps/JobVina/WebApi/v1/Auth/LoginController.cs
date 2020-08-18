using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobVina.WebApi.v1.Auth
{
    public class LoginController : ApiController
    {
        public LoginController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView GetIndex() {
            return Json("Xin chào");
        }
    }
}

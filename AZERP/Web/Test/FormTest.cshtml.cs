using AZWeb.Extensions;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Tesst
{
    public class FormTest : PageModule
    {
  
        public FormTest(IHttpContextAccessor httpContext) : base(httpContext)
        {
            
        }
        public IView Get() {
            return View();
        }
      
    }
}

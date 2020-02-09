using AZCore.HRM.Web.Modules.Login;
using AZCore.Web.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace AZCore.HRM.Pages
{
    public class IndexModel : AZPage
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger, IRazorViewEngine razorViewEngine)
        {
            _razorViewEngine = razorViewEngine;
            _logger = logger;
        }

        public  void  OnGet()
        {
            string html = new FormLogin().InitModule(this.HttpContext).ToString();
            if (html == "") { }
        }
       
    }
}

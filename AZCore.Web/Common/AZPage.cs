using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZCore.Web.Common
{
    public class AZPage : PageModel
    {
        /// <summary>
        /// Mở ra phương thức khởi tạo
        /// </summary>
        protected virtual void InitData() { }
        protected virtual void RenderView(HttpContext HttpContext)
        {
            // HttpContext.Response.WriteAsync((HttpContext.Items[AZCoreWeb.KeyHtmlModule] as IModuleResult).Html);
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            InitData();
            context.HttpContext.Items[AZCoreWeb.KeyHtmlModule] = this.LoadModuleFromUrl();
            base.OnPageHandlerExecuting(context);
        }
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
            this.RenderView(context.HttpContext);
        }
    }
}

using AZCore.Web.Common.Module;
using AZCore.Web.Configs;
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
           // HttpContext.Response.WriteAsync(this.LoadThemeFromUrl());
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            InitData();
            var configs = context.HttpContext.GetService<IPagesConfig>();
            var ModuleContent = this.LoadModuleFromUrl();
            if (ModuleContent.CSS == null) ModuleContent.CSS = new System.Collections.Generic.List<Configs.ContentTag>();
            if (ModuleContent.JS == null) ModuleContent.JS = new System.Collections.Generic.List<Configs.ContentTag>();
            if (configs.Head!=null)
            {
                ModuleContent.CSS.AddRange(configs.Head.Stypes);
                ModuleContent.JS.AddRange(configs.Head.Scripts);
            }
            context.HttpContext.Items[AZCoreWeb.KeyHtmlModule] = ModuleContent;
            base.OnPageHandlerExecuting(context);
        }
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
            this.RenderView(context.HttpContext);
        }
    }
}

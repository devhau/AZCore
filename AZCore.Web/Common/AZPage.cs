using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AZCore.Web.Common
{
    public class AZPage: PageModel
    {
        private static Regex regexPages = new Regex("([A-Za-z0-9.-]+).Pages", RegexOptions.IgnoreCase);
        /// <summary>
        /// Mở ra phương thức khởi tạo
        /// </summary>
        protected virtual void InitData() { }
        protected virtual void RenderView(HttpContext HttpContext) {
            HttpContext.Response.WriteAsync((HttpContext.Items[AZCoreWeb.KeyHtmlModule] as IModuleResult).Html);
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            InitData();
            this.LoadModuleFromUrl();
            context.HttpContext.Items[AZCoreWeb.KeyHtmlModule] = LoadModule("Home").InitModule(context.HttpContext).GetResult();
            base.OnPageHandlerExecuting(context);
        }
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
            this.RenderView(context.HttpContext);
        }
        public IModule LoadModule(Type type) => type.CreateInstance<IModule>();
        public IModule LoadModule(string nameModule) => LoadWeb(nameModule, "Modules");
        public IModule LoadWeb(string name, string typeWeb = "Modules") {

          string namePage=   this.GetType().FullName;
            if (regexPages.IsMatch(namePage)) {
                var m = regexPages.Match(namePage);
                return this.GetType().Assembly.GetType(string.Format("{0}.Web.{2}.{1}.Form{1}", m.Groups[1].Value, name, typeWeb)).CreateInstance<IModule>();
            }

            return null;
        }

    }
}

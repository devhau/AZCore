using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public abstract class TagHelperBase : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public UserInfo User { get; private set; }
        public string TagId { get; private set; }
        [HtmlAttributeName("class")]
        public virtual string TagClass { get; set; }
        [HtmlAttributeName("for-permission")]
        public virtual string PermissionCode { get; set; }
        [HtmlAttributeName("is-show")]
        public virtual bool TagShow { get; set; } = true;
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        protected HttpContext HttpContext => ViewContext?.HttpContext;
        protected string Title { get => Html.Title; set => Html.Title = value; }
        protected string Description { get => Html.Description; set => Html.Description = value; }
        protected string Keyword { get => Html.Keyword; set => Html.Keyword = value; }
        protected HtmlContent Html { get => this.HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
        public Action<TagHelperBase> TagExtend { get; set; }
        protected string PathModule { get; private set; }
        
        protected string GetContentFile(string file) {
            return File.ReadAllText(string.Format("{0}/{1}",PathModule,file));
        }
        public void AddMeta(string name, string content)
        {
            this.Html.AddMeta(name, content);
        }
        public void AddJS(string Code, string link= "", string CDN = "")
        {
            this.Html.AddJS(Code, link, CDN);
        }
        public void AddCSS(string Code, string link = "", string CDN = "")
        {
            this.Html.AddCSS(Code, link, CDN);
        }
        public override void Init(TagHelperContext context)
        {
            this.User = this.HttpContext.GetSession<UserInfo>(AZWebConstant.SessionUser);
            if (this.User == null)
            {
                this.User = this.HttpContext.GetCookie<UserInfo>(AZWebConstant.CookieUser);
                if (this.User != null)
                {
                    this.HttpContext.SetSession(AZWebConstant.SessionUser, this.User);
                }
            }
            this.TagId = string.Format("az{0}", Guid.NewGuid().ToString().Replace("-", ""));
            PathModule = Path.GetDirectoryName(string.Format("{0}/{1}", Directory.GetCurrentDirectory(),this.ViewContext.ExecutingFilePath));
            base.Init(context);
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";
            if (User!=null&&!User.HasPermission(PermissionCode)||!TagShow) {
                output.SuppressOutput();
                return;
            }
            StringBuilder htmlBuild = new StringBuilder();
            await ProcessAsync(context, output,htmlBuild);
            if (htmlBuild.Length > 0) {
                output.Content.SetHtmlContent(htmlBuild.ToString());
            }
        }
        public abstract Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild);
    }
}

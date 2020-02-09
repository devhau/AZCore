using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Rule
{
    public class AZRewriteRule : IRule
    {
        /// <summary>
        /// Lấy ra đường link đang thực hiện request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetUrl(HttpContext context)
        {
            return context.Request.Path;
        }
        /// <summary>
        /// Mở ra phương thức lấy đường link thật từ đường link ảo
        /// </summary>
        /// <param name="urlGetten"></param>
        /// <returns></returns>
        public virtual string GetMatchingRewrite(string urlGetten)
        {
            return urlGetten;
           // throw new Exception("Chưa viết lại hàm GetMatchingRewrite khi kế thừa RewriteBase");
        }
        public void ApplyRule(RewriteContext context)
        { // Lấy ra Url đang thực hiện request
            var url = GetUrl(context.HttpContext);

            // Map lấy ra url thật
            var rewrite = this.GetMatchingRewrite(url);

            // Nếu không lấy được thì trả url có nội dung rỗng
            if (rewrite==null)
                rewrite = "/Services/Empty.aspx";

            // Lấy các QueryString
            var newFilePath = rewrite.IndexOf("?") > 0 ? rewrite.Substring(0, rewrite.IndexOf("?")) : rewrite;

            foreach (var k in context.HttpContext.Request.Query.Keys)
                rewrite += string.Format("&{0}={1}",k, context.HttpContext.Request.Query[k]);

            context.HttpContext.Request.Path = new Microsoft.AspNetCore.Http.PathString("/index");
            context.HttpContext.Items["AZ"] = "Xin chào";
            context.Result = RuleResult.SkipRemainingRules;
        }
    }
}

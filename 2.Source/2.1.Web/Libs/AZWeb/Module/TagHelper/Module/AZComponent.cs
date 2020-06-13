using AZWeb.Extensions;
using AZWeb.Module.Common;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-component")]
    public class AZComponent : TagHelperBase
    {
        [HtmlAttributeName("component")]
        public string PathComponent { get; set; }
        [HtmlAttributeName("model")]
        public object ModelComponent { get; set; } = "";
        RenderView renderView { get; set; }
        public override void Init(TagHelperContext context)
        {

            this.renderView = new RenderView(this.HttpContext);
            base.Init(context);
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            var rs = await this.renderView.GetContentHtmlFromView(new HtmlView()
            {
                Model = ModelComponent,
                ViewName = PathComponent,
                Path = this.PathModule,
            });
            htmlBuild.Append(rs.GetString());
            await Task.CompletedTask;
        }
    }
}

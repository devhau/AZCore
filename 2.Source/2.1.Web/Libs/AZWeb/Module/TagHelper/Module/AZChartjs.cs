using AZCore.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    public class ChartOption
    {
        public string type {get;set;}
        public dynamic data { get; set; } = new { };
        public dynamic options { get; set; } = new { };
    }
    public class AZChartjs : TagHelperBase
    {
        public string Heigth { get; set; } = "300px";
        public string Width { get; set; } = "100%";
        public ChartOption Option { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            htmlBuild.Append("<div class=\"az-chartjs\">");
            htmlBuild.AppendFormat("<canvas class=\"chartjs {0}\" style=\"display: block; height: {1}; width: {2};\"></canvas>", this.TagClass,this.Heigth,this.Width);
            htmlBuild.Append("</div>");
          this.AddJS(string.Format("new Chart($('.{1}'),{0});", Option?.ToJson(),this.TagId));
            return Task.CompletedTask;
        }
    }
}

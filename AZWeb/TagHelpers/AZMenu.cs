using AZWeb.Common;
using AZWeb.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Text;

namespace AZWeb.TagHelpers
{
    [HtmlTargetElement("az-menu")]
    public class AZMenu : AZTagHelper
    {
        [HtmlAttributeName("prex")]
        public string prex { get; set; } = "";
        [HtmlAttributeName("menus")]
        public List<MenuItemTag> Menus { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            StringBuilder htmlMenu = new StringBuilder();
            RenderMenu(htmlMenu,this.Menus,true);
            output.Content.SetHtmlContent(htmlMenu.ToString());
        }
        private void RenderMenu(StringBuilder htmlMenu, List<MenuItemTag> menus, bool isMain = false)
        {
            if (menus == null|| menus.Count==0) return;
            if (isMain)
            {
                htmlMenu.Append("<ul class=\"nav nav-pills nav-sidebar flex-column\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">");
                foreach (var item in menus)
                {
                    htmlMenu.Append(string.Format("<li class=\"nav-item {0}\">", item.Menus != null && item.Menus.Count > 0 ? "has-treeview" : ""));
                    htmlMenu.Append(string.Format("<a href=\"{0}{1}\" class=\"nav-link az-link\"><i class=\"{2}\"></i><p>{3}{4}{5}</p></a>", prex, item.Link, item.Icon, item.Title, item.Menus != null && item.Menus.Count > 0 ? "<i class=\"fas fa-angle-left right\"></i>":"", "<span class=\"badge badge-info right\">New</span>"));
                    this.RenderMenu(htmlMenu, item.Menus);
                    htmlMenu.Append(string.Format("</li>"));
                }
                htmlMenu.Append("</ul>");
            }
            else
            {
                htmlMenu.Append("<ul class=\"nav nav-treeview\">");
                foreach (var item in menus)
                {
                    htmlMenu.Append(string.Format("<li class=\"nav-item {0}\">", item.Menus != null && item.Menus.Count > 0 ? "has-treeview" : ""));
                    htmlMenu.Append(string.Format("<a href=\"{0}{1}\" class=\"nav-link az-link\"><i class=\"{2}\"></i><p>{3}{4}{5}</p></a>", prex, item.Link, item.Icon, item.Title, item.Menus != null && item.Menus.Count > 0 ? "<i class=\"fas fa-angle-left right\"></i>" : "", "<span class=\"badge badge-info right\">New</span>"));
                    this.RenderMenu(htmlMenu, item.Menus);
                    htmlMenu.Append(string.Format("</li>"));
                }
                htmlMenu.Append("</ul>");
            }


        }
    }
}

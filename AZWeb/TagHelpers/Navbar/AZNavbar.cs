using AZWeb.Common;
using AZWeb.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Navbar
{
    [HtmlTargetElement("az-navabar")]
    public class AZNavbar: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("az-link")]
        public string AZLink { get; set; } = "az-link";
        [HtmlAttributeName("class")]
        public string NavbarClass { get; set; } = "navbar-nav";
        [HtmlAttributeName("class-item")]
        public string NavbarItemClass { get; set; } = "nav-item";
        [HtmlAttributeName("class-link")]
        public string NavbarLinkClass { get; set; } = "nav-link";
        [HtmlAttributeName("class-dropdown")]
        public string NavbarDropdownClass { get; set; } = "dropdown";
        [HtmlAttributeName("class-dropdown-toggle")]
        public string DropdownToggleClass { get; set; } = "dropdown-toggle";
        [HtmlAttributeName("class-dropdown-menu")]
        public string DropdownMenuClass { get; set; } = "dropdown-menu border-0 shadow";
        [HtmlAttributeName("class-dropdown-item")]
        public string DropdownItemClass { get; set; } = "dropdown-item";
        [HtmlAttributeName("id")]
        public string NavbarId { get; set; }

        [HtmlAttributeName("menus")]
        public List<MenuItemTag> Menus { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int subMenuIndex = 1;
            this.NavbarClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            htmlBuild.AppendFormat("<ul class=\"{0}\">",this.NavbarClass);
            foreach (var item in Menus) {
                if (item.Menus != null && item.Menus.Count > 0)
                {
                    //
                    htmlBuild.AppendFormat("<li class=\"{0} {1}\">", this.NavbarItemClass, this.NavbarDropdownClass);
                    htmlBuild.AppendFormat("<a id=\"SubMenu{0}\" href=\"#\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"true\" class=\"{1} {2}\"><i class=\"{4}\"/> {3}</a>", subMenuIndex, NavbarLinkClass, DropdownToggleClass, item.Title, item.Icon);
                    htmlBuild.AppendFormat("<ul aria-labelledby=\"SubMenu{0}\" class=\"{1}\">", subMenuIndex, DropdownMenuClass);
                    foreach (var subItem in item.Menus) {
                        htmlBuild.AppendFormat("<li class=\"{0}\" ><a href=\"{1}\" class=\"{2} {3}\"><i class=\"{5}\"/> {4}</a></li>", "", subItem.Link, this.DropdownItemClass, this.AZLink, subItem.Title, subItem.Icon);
                    }
                    htmlBuild.Append("</ul>");
                    htmlBuild.Append("</li>");
                    subMenuIndex++;
                }
                else
                {
                    htmlBuild.AppendFormat("<li class=\"{0}\" ><a href=\"{1}\" class=\"{2} {3}\"><i class=\"{5}\"/> {4}</a></li>", this.NavbarItemClass, item.Link, this.NavbarLinkClass, this.AZLink, item.Title,item.Icon);
                }
            }
            htmlBuild.Append("</ul>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }
}

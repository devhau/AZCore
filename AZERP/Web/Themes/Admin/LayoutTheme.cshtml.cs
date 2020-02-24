using AZWeb.Common.Module;
using AZWeb.Configs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZ.Web.Themes.Admin
{
    public class LayoutTheme: ThemeBase
    {
        public LayoutTheme(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public List<MenuItemTag> MenuLeft { get; set; }
        public List<MenuItemTag> MenuTop { get; set; }

        public MenuTag GetMenuPostion(MenuPosition ps) {
           return PagesConfig.Menu.FirstOrDefault(r=>r.Postion == ps);
        }
        protected override void IntData()
        {
            this.MenuLeft = GetMenuPostion(MenuPosition.Left)?.MenuItem;
            this.MenuTop = GetMenuPostion(MenuPosition.Top)?.MenuItem;
        }
    }
}

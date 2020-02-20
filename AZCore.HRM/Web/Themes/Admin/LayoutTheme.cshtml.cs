using AZCore.Web.Common.Module;
using AZCore.Web.Configs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Themes.Admin
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

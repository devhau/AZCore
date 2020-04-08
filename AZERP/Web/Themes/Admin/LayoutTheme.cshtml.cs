
using AZWeb.Configs;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Themes.Admin
{
    public class LayoutTheme: ThemeBase
    {
        IPagesConfig PagesConfig;
        public LayoutTheme(IHttpContextAccessor httpContext , IPagesConfig _PagesConfig) : base(httpContext)
        {
            PagesConfig = _PagesConfig;
        }

        public List<MenuItemTag> MenuLeft { get; set; }
        public List<MenuItemTag> MenuTop { get; set; }

        public MenuTag GetMenuPostion(MenuPosition ps) {
           return PagesConfig.Menu.FirstOrDefault(r=>r.Postion == ps);
        }
        protected override void IntData()
        {
            base.IntData();
            this.MenuLeft = GetMenuPostion(MenuPosition.Left)?.MenuItem;
            this.MenuTop = GetMenuPostion(MenuPosition.Top)?.MenuItem;
            
        }
    }
}

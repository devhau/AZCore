using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public class ThemeBase:ModuleBase
    {
        public string GetHtml() {
            return View().Html;
        }
    }

}

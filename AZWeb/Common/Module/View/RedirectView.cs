using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Module.View
{
    public class RedirectView : IRedirectView
    {
        public RedirectView() { }
        public RedirectView(string _Redirect) { this.Redirect = _Redirect; }
        public string Redirect { get; set; }
    }
}

using AZWeb.Module.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.View
{
    public class HtmlView : IView
    {
        public IModule Module { get; set; }
        public string Path { get; set; }
        public string ViewName { get; set; }
        public Object Model { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HubUrlAttribute : Attribute
    {
        public HubUrlAttribute() { }
        public HubUrlAttribute(string url) { this.Url = url; }
        public string Url { get; set; } 
    }
}

using AZCore.Web.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public interface IModuleResult
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        string Html { get; set; }
         List<ContentTag> JS { get; set; }
         List<ContentTag> CSS { get; set; }
    }
    public class ModuleResult : IModuleResult
    {
        public string Html { get; set; }
        public List<ContentTag> JS { get; set; }
        public List<ContentTag> CSS { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
    }
}

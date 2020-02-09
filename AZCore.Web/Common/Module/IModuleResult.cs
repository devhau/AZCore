using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public interface IModuleResult
    {
        public string Html { get; set; }
        public List<String> JS { get; set; }
        public List<String> CSS { get; set; }
    }
    public class ModuleResult : IModuleResult
    {
        public string Html { get; set; }
        public List<string> JS { get; set; }
        public List<string> CSS { get; set; }
    }
}

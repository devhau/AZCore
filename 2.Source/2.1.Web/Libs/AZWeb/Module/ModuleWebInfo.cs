using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    public class ModuleWebInfo
    {
        public const string Key = "AZWeb.Module.ModuleWebInfo";
        public string ModulePath { get; set; }
        public string MethodName { get; set; }
        public static Dictionary<string, Type> dicModule = new Dictionary<string, Type>();
        public static Dictionary<string, string> Rewrites = new Dictionary<string, string>();
        public static Type GetType(string name) => dicModule.ContainsKey(name) ? dicModule[name] : null;
    }
}

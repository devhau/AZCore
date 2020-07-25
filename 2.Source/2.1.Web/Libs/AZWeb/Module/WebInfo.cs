using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AZWeb.Module
{
    public class WebInfo
    {
        public static readonly string Namepace = Assembly.GetEntryAssembly().GetName().Name;
        public static Stream ReadStreamFromResource(string path, Assembly target = null) {
            if (target == null) target = Assembly.GetEntryAssembly();
            return target.GetManifestResourceStream(path.Replace("\\", ".").Replace("/", ".").Replace("..", "."));
        }
        public static string ReadAllTextFromResource(string path, Assembly target = null)
        {
            using (var fileStream = ReadStreamFromResource(path,target))
            {
                if (fileStream != null)
                {
                    using StreamReader reader = new StreamReader(fileStream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
        public const string Key = "AZWeb.Module.ModuleWebInfo";
        public string ModulePath { get; set; }
        public string MethodName { get; set; }
        public bool IsAuto { get; set; }
        public static Dictionary<string, Type> dicModule = new Dictionary<string, Type>();
        public static Dictionary<string, string> Rewrites = new Dictionary<string, string>();
        public static Type GetType(string name) => dicModule.ContainsKey(name) ? dicModule[name] : null;
    }
}

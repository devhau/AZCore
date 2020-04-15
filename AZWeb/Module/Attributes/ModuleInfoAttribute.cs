using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ModuleInfoAttribute : Attribute
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }
}

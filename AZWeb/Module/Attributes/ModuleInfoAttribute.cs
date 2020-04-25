using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ModuleInfoAttribute : Attribute
    {
        public string Title { get; set; }
        public string ViewCode { get; set; }
        public string AddCode { get; set; }
        public string EditCode { get; set; }
        public string RemoveCode { get; set; }
        public string ExportCode { get; set; }
        public string ImportCode { get; set; }
    }
}

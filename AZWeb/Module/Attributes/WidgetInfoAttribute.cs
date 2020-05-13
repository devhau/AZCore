using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WidgetInfoAttribute: Attribute
    {
        public string Name { get; set; }
    }
}

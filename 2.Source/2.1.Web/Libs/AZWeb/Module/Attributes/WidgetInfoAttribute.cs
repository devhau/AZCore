using AZWeb.Module.Common;
using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WidgetInfoAttribute : Attribute
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public WidgetType Type { get; set; } = WidgetType.InfoBox;
        public string BackgroundColorClass { get; set; } = "";
        public string IconColorClass { get; set; } = "bg-info";
        public WidgetWidth WidthClass { get; set; } = WidgetWidth.Col3;
        public string Permission { get; set; }
    }
}

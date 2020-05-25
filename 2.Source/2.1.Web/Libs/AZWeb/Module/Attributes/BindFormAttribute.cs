using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class BindFormAttribute : System.Attribute
    {
        public string FromName { get; set; }
    }
}

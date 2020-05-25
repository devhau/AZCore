using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field, AllowMultiple = false)]
    public sealed class BindServiceAttribute : Attribute
    {
    }
}

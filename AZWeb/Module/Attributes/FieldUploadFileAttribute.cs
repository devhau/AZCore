using System;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldUploadFileAttribute : Attribute
    {
        public string Prefix { get; set; } = "";
        public bool IsGenAutoNamFile { get; set; } = false;
        public string Separator { get; set; } = ";";
        public bool UseFullPath { get; set; } = true;

    }
}

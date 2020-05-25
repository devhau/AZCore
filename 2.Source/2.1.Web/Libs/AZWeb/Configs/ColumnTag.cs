using System;

namespace AZWeb.Configs
{
    [Serializable]
    public class ColumnTag
    {
        public string Title { get; set; }
        public string FieldName { get; set; }
        public string Width { get; set; }
        public string FormatString { get; set; }
    }
}

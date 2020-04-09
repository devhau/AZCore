using AZCore.Excel;
using System;

namespace AZWeb.Module.Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TableColumnAttribute: System.Attribute, IExcelColumn
    {
        public string Title { get; set; }
        public string FieldName { get; set; }
        public int Width { get; set; }
        public string FormatString { get; set; }
        public Type DataType { get; set; }
        public bool IsQRCode { get; set; }
    }
}

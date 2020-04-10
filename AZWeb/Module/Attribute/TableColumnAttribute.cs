using AZCore.Excel;
using System;
using System.Drawing;

namespace AZWeb.Module.Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TableColumnAttribute: System.Attribute, IExcelColumn
    {
        public string Title { get; set; }
        public string FieldName { get; set; }
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int HeightCell { get; set; } = 0;
        public string FormatString { get; set; }
        public Type DataType { get; set; }
        public bool IsQRCode { get; set; }
        public Color? BackColor { get; set; }
        public Color? ForeColor { get; set; }
    }
}

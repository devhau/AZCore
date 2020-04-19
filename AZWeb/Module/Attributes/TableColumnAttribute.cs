using AZCore.Excel;
using AZWeb.Module.Enums;
using System;
using System.Drawing;

namespace AZWeb.Module.Attributes
{
    /// <summary>
    /// Thiết lập cột trong bảng dữ liệu
    /// </summary>
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
        public Color? BackColor { get; set; }
        public Color? ForeColor { get; set; }
        public string ClassColumn { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public string TextTrue { get; set; }
        public string TextFalse { get; set; }
        public string LinkFormat { get; set; }
        public DisplayColumn Display { get; set; } = DisplayColumn.Text;
        public PopupSize Popup { get; set; } = PopupSize.None;
        public bool ReLoadAfterPopupClose { get; set; }
        public string Permisson { get; set; }
    }
    
   
}

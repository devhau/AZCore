using System;
using System.Drawing;

namespace AZCore.Excel
{
    public interface IExcelColumn
    {
        string Title { get; set; }
        string FieldName { get; set; }
        int Width { get; set; }
        int Height { get; set; } 
        int HeightCell { get; set; }
        string FormatString { get; set; }
        Type DataType { get; set; }
        Color? BackColor { get; set; }
        Color? ForeColor { get; set; }
        int TotalMergeRows { get; set; }
        int TotalMergeColumns { get; set; }
    }   
}

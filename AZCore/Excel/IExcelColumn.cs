using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Excel
{
    public interface IExcelColumn
    {
       string Title { get; set; }
       string FieldName { get; set; }
       int Width { get; set; }
       string FormatString { get; set; }
       Type DataType { get; set; }
    }
}

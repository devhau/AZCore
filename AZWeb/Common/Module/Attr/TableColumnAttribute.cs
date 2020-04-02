using AZCore.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Module.Attr
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TableColumnAttribute: Attribute, IExcelColumn
    {
        public string Title { get; set; }
        public string FieldName { get; set; }
        public int Width { get; set; }
        public string FormatString { get; set; }
        public Type DataType { get; set; }
        public bool IsQRCode { get; set; }
    }
}

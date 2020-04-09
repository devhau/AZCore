using AZWeb.Module.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AZWeb.Module.View
{
    public class DownloadFileView : IView
    {
        public const string Excel = "application/vnd.ms-excel";
        public const string ExcelX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string Text = "text/plain";
        public const string PDF = "application/pdf";
        public Stream File { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        [JsonIgnore]
        public IModule Module { get; set; }
    }
}

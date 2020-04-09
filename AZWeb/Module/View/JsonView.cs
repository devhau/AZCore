using AZWeb.Module.Common;
using System;
using System.Text.Json.Serialization;

namespace AZWeb.Module.View
{
    public class JsonView : IView
    {
        [JsonIgnore]
        public IModule Module { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}

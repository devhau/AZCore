using AZWeb.Module.Common;
using System.Net;
using System.Text.Json.Serialization;

namespace AZWeb.Module.View
{
    public class JsonView : IView
    {
        [JsonIgnore]
        public IModule Module { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public object Data { get; set; }
    }
}

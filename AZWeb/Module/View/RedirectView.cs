using AZWeb.Module.Common;
using System.Text.Json.Serialization;

namespace AZWeb.Module.View
{
    public class RedirectView : IView
    {
        [JsonIgnore]
        public IModule Module { get; set; }
        public string RedirectToUrl { get; set; }
    }
}

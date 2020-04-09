using AZWeb.Module.Common;

namespace AZWeb.Module.View
{
    public class JsonView : IView
    {
        public IModule Module { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}

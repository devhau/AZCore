using AZWeb.Module.Common;

namespace AZWeb.Module.View
{
    public class RedirectView : IView
    {
        public IModule Module { get; set; }
        public string RedirectToUrl { get; set; }
    }
}

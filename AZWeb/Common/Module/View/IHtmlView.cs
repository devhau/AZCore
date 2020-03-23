using AZWeb.Configs;
using System;
using System.Collections.Generic;

namespace AZWeb.Common.Module.View
{
    public interface IHtmlView : IView, IRedirectView
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        string Html { get; set; }

        List<ContentTag> JS { get; set; }
        List<ContentTag> CSS { get; set; }
        bool IsTheme { get; set; }
        IView DoView(Action<IView> ac);

    }
}

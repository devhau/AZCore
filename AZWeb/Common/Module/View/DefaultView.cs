﻿using AZWeb.Configs;
using System;
using System.Collections.Generic;

namespace AZWeb.Common.Module.View
{
    public class DefaultView : IHtmlView
    {
        public string Html { get; set; }
        public List<ContentTag> JS { get; set; } = new List<ContentTag>();
        public List<ContentTag> CSS { get; set; } = new List<ContentTag>();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public bool IsTheme { get; set; } = true;

        public IView DoView(Action<IView> ac)
        {
            if (ac != null)
            {
                ac(this);
            }
            return this;
        }
    }
}

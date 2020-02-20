using AZCore.Web.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public interface IViewResult
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        string Html { get; set; }
         List<ContentTag> JS { get; set; }
        List<ContentTag> CSS { get; set; }
        bool IsTheme { get; set; }
        IViewResult DoResult(Action<IViewResult> ac);
    }
    public class ViewResult : IViewResult
    {
        public string Html { get; set; }
        public List<ContentTag> JS { get; set; } = new List<ContentTag>();
        public List<ContentTag> CSS { get; set; } = new List<ContentTag>();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public Action<IViewResult> ActionResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsTheme { get; set; } = true;

        public IViewResult DoResult(Action<IViewResult> ac)
        {
            if (ac!=null) {
                ac(this);
            }
            return this;
        }
    }
}

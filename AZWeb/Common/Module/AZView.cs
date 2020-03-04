using AZWeb.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Module
{
    public  interface IResult{
    }
    public interface IView: IResult
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
    public class AZView : IView
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
            if (ac!=null) {
                ac(this);
            }
            return this;
        }
    }
}

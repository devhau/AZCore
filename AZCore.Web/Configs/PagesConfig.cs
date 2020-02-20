using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AZCore.Utility.Xml;
namespace AZCore.Web.Configs
{
    public interface IPagesConfig {
        List<PageTag> Pages { set; get; }
        HeadTag Head { set; get; }
        string GetMatchingRewrite(string url);
        string extenstion { get; set; }
        string UrlRealDefault { get; set; }
        string Theme { get; set; }
        public List<MenuTag> Menu { set; get; }

    }
    /// <summary>
    /// Thông tin Settings các trang
    /// <root>    
    ///         <page></page>    
    /// </root>
    /// </summary>
    [Serializable]
    [XmlRoot("root")]
    public class PagesConfig : ConfigBase, IPagesConfig
    {
        [XmlElement("web-extenstion")]
        public string extenstion { get; set; } = ".az";
        [XmlElement("web-default")]
        public string UrlRealDefault { get; set; } = "m=home";
        [XmlElement("web-theme")]
        public string Theme { get; set; } = "Admin";
        /// <summary>
        /// Định nghĩa các pageTag
        /// </summary>        
        [XmlElement("page")]
        public List<PageTag> Pages { set; get; }
        /// <summary>
        /// Định nghĩa các pageTag
        /// </summary>        
        [XmlElement("head")]
        public HeadTag Head { set; get; }
        /// <summary>
        /// Định nghĩa các pageTag
        /// </summary>        
        [XmlElement("menu")]
        public List<MenuTag> Menu { set; get; }


        public string GetMatchingRewrite(string url)
        {
            if (Pages != null)
            {
                foreach (var page in Pages)
                {
                    foreach (var tag in page.Tags)
                    {
                        if (url.EndsWith(tag.ViturlPath))
                        {
                            return  tag.Real;
                        }
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Lấy ra đường dẫn chưa file config
        /// </summary>
        /// <returns></returns>
        public override string GetPath()
        {
            return ("Web/Configs/Setting.config");
        }
    }
}

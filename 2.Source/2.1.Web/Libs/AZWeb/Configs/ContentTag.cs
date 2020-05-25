using System;
using System.Xml.Serialization;

namespace AZWeb.Configs
{
    public interface IContentTag {
         string Link { get; set; }
        string CDN { get; set; }
        string Code { get; set; }
    }
    [Serializable]
    public class ContentTag: IContentTag
    {
        [XmlAttribute("src")]
        public string Link { get; set; }
        [XmlAttribute("cdn")]
        public string CDN { get; set; }
        [XmlText]
        public string Code { get; set; }
    }
}

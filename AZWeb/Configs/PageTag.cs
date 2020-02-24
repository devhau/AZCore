using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZWeb.Configs
{

    [Serializable]
    public class PageTag
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("url")]
        public List<UrlTag> Tags { get; set; }
    }
}

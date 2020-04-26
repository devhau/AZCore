using AZWeb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZWeb.Configs
{
    [Serializable]
    public class HeadTag
    {
        [XmlElement("script")]
        public List<ContentTag> Scripts { get; set; }      
        [XmlElement("style")]
        public List<ContentTag> Stypes { get; set; }
        [XmlElement("meta")]
        public List<MetaTag> Metas { get; set; }
    }
    
}

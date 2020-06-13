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
        [XmlElement("meta")]
        public List<MetaTag> Metas { get; set; }
    }
    
}

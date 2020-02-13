using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZCore.Web.Configs
{
    public interface IContentTag {
         string Link { get; set; }
         string Code { get; set; }
    }
    [Serializable]
    public class ContentTag: IContentTag
    {
        [XmlAttribute("src")]
        public string Link { get; set; }
        [XmlText]
        public string Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZWeb.Configs
{
    [Serializable]
    public class MenuItemTag
    {
        [XmlAttribute("class")]
        public string MenuClass { get; set; }
        [XmlAttribute("icon")]
        public string Icon { get; set; }
        [XmlAttribute("tilte")]
        public string Title { get; set; }
        [XmlAttribute("link")]
        public string Link { get; set; }
        [XmlAttribute("link-badge")]
        public string LinkBadge { get; set; }
        [XmlAttribute("badge")]
        public string Badge { get; set; } = "New";
        [XmlAttribute("cmd")]
        public string CMD { get; set; }
        [XmlAttribute("permission")]
        public string PermissionKey { get; set; }
        [XmlElement("sub-item")]
        public List<MenuItemTag> Menus { get; set; }
    }
}

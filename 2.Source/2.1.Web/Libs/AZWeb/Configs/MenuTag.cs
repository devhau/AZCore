using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZWeb.Configs
{
    public enum MenuPosition 
    {
        Top=1,
        Left=2,
        Ringht=3
    }
    [Serializable]
    public class MenuTag
    {
        [XmlAttribute("postion")]
        public MenuPosition Postion { get; set; }
        [XmlElement("menu-item")]
        public List<MenuItemTag> MenuItem { get; set; }
    }
}

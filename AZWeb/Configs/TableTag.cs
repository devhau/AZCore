using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZWeb.Configs
{
    [Serializable]
    public class TableTag
    {
        public TableTag() { 
        
        
        }
        [XmlAttribute("is-index")]
        public bool IsIndex { get; set; } = true;
        [XmlAttribute("is-edit")]
        public bool IsEdit { get; set; } = true;
        [XmlAttribute("is-delete")]
        public bool IsDelete { get; set; } = true;
        [XmlElement("columns")]
        public List<ColumnTag> Columns { get; set; }
    }
}

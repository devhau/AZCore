using AZCore.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AZCore.Web.Configs
{
    [Serializable]
    public class HeadTag
    {
        private string  textScript { get; set; }
        public string Script
        {
            get
            {
                if (string.IsNullOrEmpty(textScript)) { this.textScript = this.GetContent(this.Scripts); }
                return textScript;
            }
        }
        [XmlElement("script")]
        public List<ContentTag> Scripts { get; set; }
        private string textStyle { get; set; }
        public string Style { get {
                if (string.IsNullOrEmpty(textStyle)) { }
                return textStyle;
            } }
        [XmlElement("style")]
        public List<ContentTag> Stypes { get; set; }
        [XmlElement("meta")]
        public List<MetaTag> Metas { get; set; }
        private string GetContent(List<ContentTag> tags) {

            String content = "";
            foreach (var item in tags) {
                if (string.IsNullOrEmpty(item.Code)) 
                {

                    content += item.Link.LoadTextFile();
                }
                else 
                {
                    content += item.Code;
                }
            
            
            }
            return content;
        
        
        }
    }
    
}

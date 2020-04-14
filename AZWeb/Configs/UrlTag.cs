using System;
using System.Xml.Serialization;
namespace AZWeb.Configs
{
    /// <summary>
    /// Tag để định nghĩa đường link của Page
    /// ví dụ: <url virtual="home" real="m=1" />
    /// virtual: Thông tin đường link ảo
    /// real: Tham số parameter QueryString
    /// </summary>
    [Serializable]
    public class UrlTag
    {
        /// <summary>
        /// Nhóm Module
        /// </summary>
        [XmlAttribute("group")]
        public string Group { get; set; }
        /// <summary>
        /// Đường link ảo
        /// </summary>
        [XmlAttribute("virtual")]
        public string ViturlPath { set; get; }

        /// <summary>
        /// Thông tin cho đường link thật
        /// </summary>
        [XmlAttribute("real")]
        public string Real { set; get; }
    }
}

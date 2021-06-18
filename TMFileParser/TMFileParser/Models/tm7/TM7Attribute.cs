using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Attribute
    {
        [XmlElement("IsExtension")]
        public bool isExtension { get; set; }
        [XmlElement("IsInherited")]
        public bool isInherited { get; set; }
        [XmlElement("DisplayName")]
        public string displayName { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("Inheritance")]
        public string inheritance { get; set; }
        [XmlElement("Mode")]
        public string mode { get; set; }
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("Type")]
        public string type { get; set; }
        [XmlElement("AttributeValues")]
        public TM7AttributeValues attributeValues { get; set; } 

    }
}

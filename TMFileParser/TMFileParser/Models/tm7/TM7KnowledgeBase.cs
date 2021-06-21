using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    [XmlRoot("KnowledgeBase", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.KnowledgeBase")]
    public class TM7KnowledgeBase
    {
        [XmlAttribute("Id")]
        public string id { get; set; }
        [XmlElement("Manifest")]
        public TM7Manifest manifest { get; set; }

        [XmlElement("ThreatMetaData")]
        public TM7ThreatMetaData threatMetaData { get; set; }

        [XmlElement("GenericElements")]
        public TM7GenericElements genericElements { get; set; }
        [XmlElement("ThreatCategories")]
        public TM7ThreatCategories threatCategories { get; set; }
        [XmlElement("ThreatTypes")]
        public TM7ThreatTypes threatTypes { get; set; }
    }

}

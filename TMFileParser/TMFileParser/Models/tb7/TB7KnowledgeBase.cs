using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    [XmlRoot("KnowledgeBase")]
    public class TB7KnowledgeBase
    {
        [XmlElement("Manifest")]
        public TB7Manifest manifest { get; set; }

        [XmlElement("ThreatMetaData")]
        public TB7ThreatMetaData threatMetaData { get; set; }
    }

}

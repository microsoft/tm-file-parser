﻿using System;
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
        [XmlElement("GenericElements")]
        public TB7GenericElements genericElements { get; set; }
        [XmlElement("StandardElements")]
        public TB7StandardElements standardElements { get; set; }
        [XmlElement("ThreatCategories")]
        public TB7ThreatCategories threatCategories { get; set; }
        [XmlElement("ThreatTypes")]
        public TB7ThreatTypes threatTypes { get; set; }
    }

}

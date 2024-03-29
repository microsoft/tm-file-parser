﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ThreatCategory
    {
        [XmlElement("IsExtension")]
        public bool isExtension { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("ShortDescription")]
        public string shortDescription { get; set; }
        [XmlElement("LongDescription")]
        public string longDescription { get; set; }
    }
}

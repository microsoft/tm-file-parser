using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ThreatCategory
    {
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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ThreatCategories
    {
        [XmlElement("ThreatCategory")]
        public List<TB7ThreatCategory> threatCategory { get; set; }
    }
}

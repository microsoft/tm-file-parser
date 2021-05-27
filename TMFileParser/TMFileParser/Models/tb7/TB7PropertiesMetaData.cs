using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7PropertiesMetaData
    {
        [XmlElement("ThreatMetaDatum")]
        public List<TB7ThreatMetaDatum> threatMetaDatum { get; set; }
    }
}
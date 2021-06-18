using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7PropertiesMetaData
    {
        [XmlElement("ThreatMetaDatum")]
        public List<TM7ThreatMetaDatum> threatMetaDatum { get; set; }
    }
}
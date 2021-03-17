using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ThreatMetaData
    {
        [XmlElement("IsPriorityUsed")]
        public bool isPriorityUsed { get; set; }

        [XmlElement("IsStatusUsed")]
        public bool isStatusUsed { get; set; }

        [XmlElement("PropertiesMetaData")]
        public TB7PropertiesMetaData propertiesMetaData { get; set; }
    }
}
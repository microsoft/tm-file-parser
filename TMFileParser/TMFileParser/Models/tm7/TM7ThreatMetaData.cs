using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ThreatMetaData
    {
        [XmlElement("IsPriorityUsed")]
        public bool isPriorityUsed { get; set; }

        [XmlElement("IsStatusUsed")]
        public bool isStatusUsed { get; set; }

        [XmlElement("PropertiesMetaData")]
        public TM7PropertiesMetaData propertiesMetaData { get; set; }
    }
}
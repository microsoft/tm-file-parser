using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7MetaInformation
    {
        [XmlElement("Assumptions")]
        public string assumptions { get; set; }
        [XmlElement("Contributors")]
        public string contributors { get; set; }
        [XmlElement("ExternalDependencies")]
        public string externalDependencies { get; set; }
        [XmlElement("HighLevelSystemDescription")]
        public string highLevelSystemDescription { get; set; }
        [XmlElement("Owner")]
        public string owner { get; set; }
        [XmlElement("Reviewer")]
        public string reviewer { get; set; }
        [XmlElement("ThreatModelName")]
        public string threatModelName { get; set; }
    }
}
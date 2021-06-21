using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7KeyValueOfstringThreatpc_P0_PhOB
    {
        [XmlElement("Key")]
        public string key { get; set; }
        [XmlElement("Value")]
        public TM7ThreatInstancesValue value { get; set; }
    }
}
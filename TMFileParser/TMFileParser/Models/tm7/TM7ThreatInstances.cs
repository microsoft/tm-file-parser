using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ThreatInstances
    {
        [XmlElement("KeyValueOfstringThreatpc_P0_PhOB")]
        public List<TM7KeyValueOfstringThreatpc_P0_PhOB> keyValueOfstringThreatpc_P0_PhOB { get; set; }
    }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Lines
    {
        [XmlElement("KeyValueOfguidanyType")]
        public List<TM7LinesKeyValueOfguidanyType> keyValueOfguidanyType { get; set; }
    }
}
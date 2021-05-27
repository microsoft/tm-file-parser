using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7LinesKeyValueOfguidanyType
    {
        [XmlElement("Key")]
        public string linesKey { get; set; }
        [XmlElement("Value")]
        public TM7LinesValue value { get; set; }
    }
}
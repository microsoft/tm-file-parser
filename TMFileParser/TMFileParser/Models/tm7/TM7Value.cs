using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Value
    {
        [XmlText]
        public string value { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
    }
}
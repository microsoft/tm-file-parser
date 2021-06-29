using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7AnyType
    {
        [XmlElement("DisplayName")]
        public string DisplayName { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlElement("Value")]
        public TM7Value value { get; set; }

    }
}
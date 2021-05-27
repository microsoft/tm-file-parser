using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7AnyType
    {
        [XmlElement("DisplayName")]
        public string displayName { get; set; }
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
    }
}
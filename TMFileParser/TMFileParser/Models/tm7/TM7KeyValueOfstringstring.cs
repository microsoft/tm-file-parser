using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7KeyValueOfstringstring
    {
        [XmlElement("Key")]
        public string key { get; set; }
        [XmlElement("Value")]
        public string value { get; set; }

    }
}
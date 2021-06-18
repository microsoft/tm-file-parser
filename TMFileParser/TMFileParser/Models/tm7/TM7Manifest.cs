using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Manifest
    {
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("Version")]
        public string version { get; set; }
        [XmlElement("Author")]
        public string author { get; set; }
    }
}
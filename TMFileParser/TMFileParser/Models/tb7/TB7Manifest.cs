using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7Manifest
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("id")]
        public string id { get; set; }
        [XmlAttribute("version")]
        public string version { get; set; }
        [XmlAttribute("author")]
        public string author { get; set; }
    }
}
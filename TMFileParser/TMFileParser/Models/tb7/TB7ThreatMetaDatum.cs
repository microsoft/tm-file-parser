using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ThreatMetaDatum
    {
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("Label")]
        public string label { get; set; }
        [XmlElement("HideFromUI")]
        public bool hideFromUI { get; set; }
        [XmlElement("Values")]
        public TB7Values values { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("AttributeType")]
        public int attributeType { get; set; }
    }
}
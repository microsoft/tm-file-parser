using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7BordersValue
    {
        [XmlElement("GenericTypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string genericTypeId { get; set; }
        [XmlElement("Guid", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string guid { get; set; }
        [XmlElement("Properties", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public TM7Properties properties { get; set; }
        [XmlElement("TypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string typeId { get; set; }
        [XmlElement("Height", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal height { get; set; }
        [XmlElement("Left", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal left { get; set; }
        [XmlElement("StrokeThickness", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal strokeThickness { get; set; }
        [XmlElement("StrokeDashArray", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string strokeDashArray { get; set; }
        [XmlElement("Top", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal top { get; set; }
        [XmlElement("Width", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal width { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlAttribute("Id")]
        public string id { get; set; }
    }
}
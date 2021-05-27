using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7LinesValue
    {
        [XmlElement("GenericTypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string genericTypeId { get; set; }
        [XmlElement("Guid", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string guid { get; set; }
        [XmlElement("SourceGuid", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string sourceGuid { get; set; }
        [XmlElement("TargetGuid", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string targetGuid { get; set; }
        [XmlElement("PortSource", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string portSource { get; set; }
        [XmlElement("PortTarget", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string portTarget { get; set; }
        [XmlElement("Properties", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public TM7Properties properties { get; set; }
        [XmlElement("TypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string typeId { get; set; }
        [XmlElement("HandleX", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal handleX { get; set; }
        [XmlElement("HandleY", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal handleY { get; set; }
        [XmlElement("SourceX", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal sourceX { get; set; }
        [XmlElement("SourceY", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal sourceY { get; set; }
        [XmlElement("TargetX", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal targetX { get; set; }
        [XmlElement("TargetY", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public decimal targetY { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
    }
}
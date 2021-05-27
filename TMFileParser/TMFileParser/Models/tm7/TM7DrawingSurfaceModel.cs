using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7DrawingSurfaceModel
    {
        [XmlElement("GenericTypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string genericTypeId { get; set; }
        [XmlElement("Guid", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string guid { get; set; }
        [XmlElement("TypeId", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public string typeId { get; set; }
        [XmlElement("Header")]
        public string header { get; set; }
        [XmlElement("Zoom")]
        public decimal zoom { get; set; }
        [XmlElement("Properties", Namespace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts")]
        public TM7Properties properties { get; set; }
        [XmlElement("Borders")]
        public TM7Borders borders { get; set; }
        [XmlElement("Lines")]
        public TM7Lines lines { get; set; }
    }
}
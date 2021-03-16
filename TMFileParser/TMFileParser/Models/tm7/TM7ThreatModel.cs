using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using TMFileParser.Models.tb7;

namespace TMFileParser.Models.tm7
{

    /// <remarks/>
    [ExcludeFromCodeCoverage]
    [XmlRoot("ThreatModel")]
    public class TM7ThreatModel
    {
        public const string TMNameSpace = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model";

        [XmlElement("DrawingSurfaceModel")]
        public TM7DrawingSurfaceList drawingSurfaceList { get; set; }

        [XmlElement("MetaInformation")]
        public TM7MetaInformation metaInformation { get; set; }

        [XmlElement("Notes")]
        public string notes { get; set; }

        [XmlElement("ThreatInstances")]
        public TM7ThreatInstances threatInstances { get; set; }

        [XmlElement("ThreatGenerationEnabled")]
        public bool threatGenerationEnabled { get; set; }

        [XmlElement("Validations")]
        public TM7Validations validations { get; set; }

        [XmlElement("KnowledgeBase")]
        public TB7KnowledgeBase knowledgeBase { get; set; }

        [XmlElement("Profile")]
        public TM7Profile profile { get; set; }

        [XmlElement("Version")]
        public string version { get; set; }

    }

}

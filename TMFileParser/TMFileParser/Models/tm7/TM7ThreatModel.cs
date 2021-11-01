using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using TMFileParser.Models.tb7;

namespace TMFileParser.Models.tm7
{

    [ExcludeFromCodeCoverage]
    [XmlRoot("ThreatModel")]
    public class TM7ThreatModel
    {
        [XmlElement("DrawingSurfaceList")]
        public TM7DrawingSurfaceList drawingSurfaceList { get; set; }

        [XmlElement("MetaInformation")]
        public TM7MetaInformation metaInformation { get; set; }

        [XmlElement("Notes")]
        public TM7Notes notes { get; set; }

        [XmlElement("ThreatInstances")]
        public TM7ThreatInstances threatInstances { get; set; }

        [XmlElement("ThreatGenerationEnabled")]
        private string threatGenerationEnabledString { get; set; }

        public bool threatGenerationEnabled
        {
            get
            {
                if (string.IsNullOrEmpty(this.threatGenerationEnabledString))
                {
                    return true;
                }
                return bool.Parse(this.threatGenerationEnabledString);
            }
        }

        [XmlElement("Validations")]
        public TM7Validations validations { get; set; }

        [XmlElement("KnowledgeBase")]
        public TM7KnowledgeBase knowledgeBase { get; set; }

        [XmlElement("Profile")]
        public TM7Profile profile { get; set; }

        [XmlElement("Version")]
        public string version { get; set; }

    }

}

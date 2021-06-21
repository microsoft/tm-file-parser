using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ThreatInstancesValue
    {
        [XmlElement("ChangedBy")]
        public string changedBy { get; set; }
        [XmlElement("DrawingSurfaceGuid")]
        public string drawingSurfaceGuid { get; set; }
        [XmlElement("Properties")]
        public TM7ThreatInstanceProperties properties { get; set; }
        [XmlElement("FlowGuid")]
        public string flowGuid { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("InteractionKey")]
        public string interactionKey { get; set; }
        [XmlElement("InteractionString")]
        public string interactionString { get; set; }
        [XmlElement("ModifiedAt")]
        public DateTime ModifiedAt { get; set; }
        [XmlElement("Priority")]
        public string Priority { get; set; }
        [XmlElement("SourceGuid")]
        public string sourceGuid { get; set; }
        [XmlElement("State")]
        public string state { get; set; }
        [XmlElement("StateInformation")]
        public string stateInformation { get; set; }
        [XmlElement("TargetGuid")]
        public string targetGuid { get; set; }
        [XmlElement("Title")]
        public string title { get; set; }
        [XmlElement("TypeId")]
        public string typeId { get; set; }
        [XmlElement("Upgraded")]
        public bool upgraded { get; set; }
        [XmlElement("UserThreatCategory")]
        public string userThreatCategory { get; set; }
        [XmlElement("UserThreatDescription")]
        public string userThreatDescription { get; set; }
        [XmlElement("UserThreatShortDescription")]
        public string userThreatShortDescription { get; set; }
        [XmlElement("Wide")]
        public bool wide { get; set; }

    }
}
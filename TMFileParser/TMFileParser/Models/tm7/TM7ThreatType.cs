using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ThreatType
    {
        [XmlElement("IsExtension")]
        public bool isExtension { get; set; }
        [XmlElement("GenerationFilters")]
        public TM7GenerationFilters generationFilters { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("ShortTitle")]
        public string shortTitle { get; set; }
        [XmlElement("Category")]
        public string category { get; set; }
        [XmlElement("RelatedCategory")]
        public string relatedCategory { get; set; }
        [XmlElement("Description")]
        public string description { get; set; }
        [XmlElement("PropertiesMetaData")]
        public TM7PropertiesMetaData propertiesMetaData { get; set; }
    }
}

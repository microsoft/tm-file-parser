using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ThreatType
    {
        [XmlElement("GenerationFilters")]
        public TB7GenerationFilters generationFilters { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("ShortTitle")]
        public string shortTitle { get; set; }
        [XmlElement("RelatedCategory")]
        public string relatedCategory { get; set; }
        [XmlElement("Category")]
        public string category { get; set; }
        [XmlElement("Description")]
        public string description { get; set; }
        [XmlElement("PropertiesMetaData")]
        public TB7PropertiesMetaData propertiesMetaData { get; set; }
    }
}

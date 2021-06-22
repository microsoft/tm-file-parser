using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7ElementType
    {
        [XmlElement("IsExtension")]
        public bool isExtension { get; set; }
        [XmlElement("AvailableToBaseModels")]
        public bool availableToBaseModels { get; set; }
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("Behavior")]
        public string behavior { get; set; }
        [XmlElement("Description")]
        public string description { get; set; }
        [XmlElement("Hidden")]
        public bool hidden { get; set; }
        [XmlElement("Representation")]
        public string representation { get; set; }
        [XmlElement("Id")]
        public string id { get; set; }
        [XmlElement("ImageLocation")]
        public string imageLocation { get; set; }
        [XmlElement("ImageSource")]
        public string imageSource { get; set; }
        [XmlElement("ParentId")]
        public string parentId { get; set; }
        [XmlElement("Shape")]
        public string shape { get; set; }
        [XmlElement("ImageStream")]
        public string imageStream { get; set; }
        
        [XmlElement("Attributes")]
        public TM7Attributes attributes { get; set; }
        [XmlElement("StencilConstraints")]
        public TM7StencilConstraints stencilConstraints { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7ElementType
    {
        [XmlElement("Name")]
        public string name { get; set; }
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
        [XmlElement("ParentElement")]
        public string parentElement { get; set; }
        [XmlElement("Image")]
        public string image { get; set; }
        [XmlElement("Attributes")]
        public TB7Attributes attributes { get; set; }
        [XmlElement("StrokeThickness")]
        public float strokeThickness { get; set; }

    }
}

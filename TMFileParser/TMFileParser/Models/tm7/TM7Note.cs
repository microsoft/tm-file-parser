using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Note
    {
        [XmlElement("AddedBy")]
        public string addedBy { get; set; }
        [XmlElement("Date")]
        public DateTime date { get; set; }
        [XmlAttribute("Id")]
        public decimal id { get; set; }
        [XmlElement("Message")]
        public string message { get; set; }

    }
}
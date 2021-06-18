using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Attributes
    {
        [XmlElement("Attribute")]
        public List<TM7Attribute> attribute { get; set; }
    }
}

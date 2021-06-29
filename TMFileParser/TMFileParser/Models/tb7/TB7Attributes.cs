using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7Attributes
    {
        [XmlElement("Attribute")]
        public List<TB7Attribute> attribute { get; set; }
    }
}

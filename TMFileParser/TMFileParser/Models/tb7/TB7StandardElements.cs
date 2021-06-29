using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7StandardElements
    {
        [XmlElement("ElementType")]
        public List<TB7ElementType> elementType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7GenericElements
    {
        [XmlElement("ElementType")]
        public List<TM7ElementType> elementType { get; set; }
    }
}

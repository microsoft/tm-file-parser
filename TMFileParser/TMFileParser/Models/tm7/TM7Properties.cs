using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7Properties
    {
        [XmlElement("anyType")]
        public List<TM7AnyType> anyType { get; set; }
    }
}
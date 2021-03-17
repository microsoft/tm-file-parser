using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7Values
    {
        [XmlElement("Value")]
        public List<string> valueList { get; set; }
    }
}
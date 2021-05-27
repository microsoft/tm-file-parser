using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tb7
{
    [ExcludeFromCodeCoverage]
    public class TB7GenerationFilters
    {
        [XmlElement("Include")]
        public string include { get; set; }
        [XmlElement("Exclude")]
        public string exclude { get; set; }

    }
}

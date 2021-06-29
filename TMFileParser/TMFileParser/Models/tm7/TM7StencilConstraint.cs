using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7StencilConstraint
    {
        [XmlElement("IsExtension")]
        public bool isExtension { get; set; }
        [XmlElement("SelectedStencilConnection")]
        public string selectedStencilConnection { get; set; }
        [XmlElement("SelectedStencilType")]
        public string selectedStencilType { get; set; }

    }
}

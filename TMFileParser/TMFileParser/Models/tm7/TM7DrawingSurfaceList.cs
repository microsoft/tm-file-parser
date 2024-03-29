﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TMFileParser.Models.tm7
{
    [ExcludeFromCodeCoverage]
    public class TM7DrawingSurfaceList
    {
        [XmlElement("DrawingSurfaceModel")]
        public List<TM7DrawingSurfaceModel> drawingSurfaceModel { get; set; }
    }
}
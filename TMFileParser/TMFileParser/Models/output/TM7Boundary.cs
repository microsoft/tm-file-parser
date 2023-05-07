﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7Boundary
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public decimal Left { get; set; }
        public decimal Top { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public List<TM7Asset> Assets { get; set; }
        public List<TM7Asset> AssetsOnBoundary { get; set; }
        public List<TM7Connector> CrossingDataflows { get; set; }
        public List<TM7Connector> Connectors { get; set; }
        public List<TM7Boundary> ChildBoundaries { get; set; }
        public List<TM7CommonBoundary> CommonBoundaries { get; set; }
    }
}

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7Diagram
    {
        public string diagram { get; set; }
        public List<TM7Boundary> boundaries { get; set; }
        public List<TM7Connector> connectors { get; set; }
        public List<TM7Asset> assets { get; set; }
    }
}

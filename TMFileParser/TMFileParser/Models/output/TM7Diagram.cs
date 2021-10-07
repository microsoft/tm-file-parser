using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7Diagram
    {
        public string diagram { get; set; }
        public List<TM7Boundary> bondaries { get; set; }
        public List<TM7Connector> connectors { get; set; }
        public List<TM7Asset> assets { get; set; }
    }
}

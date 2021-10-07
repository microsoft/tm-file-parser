using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7All
    {
        public List<TM7Diagram> diagrams { get; set; }
        public List<TM7Threat> threats { get; set; }
    }
}

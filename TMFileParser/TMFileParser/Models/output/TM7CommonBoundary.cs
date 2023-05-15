using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7CommonBoundary
    {
        public TM7BoundaryBasic Boundary { get; set; }
        public List<TM7Asset> CommonAssets { get; set; }
    }
}

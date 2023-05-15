using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7Connector
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public TM7Asset SourceAsset { get; set; }
        public TM7Asset TargetAsset { get; set; }
    }
}

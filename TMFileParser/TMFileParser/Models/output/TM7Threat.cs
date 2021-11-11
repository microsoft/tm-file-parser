using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7Threat
    {
        public string id { get; set; }
        public string diagram { get; set; }
        public string changedBy { get; set; }
        public DateTime lastModified { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string justifications { get; set; }
        public string interaction { get; set; }
        public string priority { get; set; }
    }
}

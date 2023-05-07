using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMFileParser.Models.output
{
    [ExcludeFromCodeCoverage]
    public class TM7BoundaryBasic
    {
        public TM7BoundaryBasic(TM7Boundary boundary) {
            this.Name = boundary.Name;
            this.Top = boundary.Top;
            this.Left = boundary.Left;
            this.Width = boundary.Width;
            this.Height = boundary.Height;
            this.DisplayName = boundary.DisplayName;
            this.Type = boundary.Type;
            this.Assets = boundary.Assets;
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public decimal Left { get; set; }
        public decimal Top { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public List<TM7Asset> Assets { get; set; }
    }
}

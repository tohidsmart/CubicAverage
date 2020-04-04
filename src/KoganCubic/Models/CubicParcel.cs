using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoganCubic.Models
{
    public class CubicParcel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal? Weight { get; set; }
        public CubicParcelSize Size { get; set; }
    }
}

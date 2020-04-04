using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoganCubic.Models
{
    public class CalculationRequest
    {
        public IEnumerable<CubicParcel> Objects { get; set; } = new List<CubicParcel>();
        public string Next { get; set; }
    }
}

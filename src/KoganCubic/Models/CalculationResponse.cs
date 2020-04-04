using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoganCubic.Models
{
    public class CalculationResponse
    {
        public int ParcelCount { get; set; }
        public decimal Average { get; set; }
        public decimal TotalValue { get; set; }

        public int TotalParcelCount { get; set; }
        public string Category { get; set; }
    }
}

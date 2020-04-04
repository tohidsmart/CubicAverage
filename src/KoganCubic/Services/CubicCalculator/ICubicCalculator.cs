using KoganCubic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoganCubic.Services
{
    public interface ICubicCalculator
    {
        Task<CalculationResponse> GetAverageAsync();
    }
}

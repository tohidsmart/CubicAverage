using KoganCubic.Models;
using System.Threading.Tasks;

namespace KoganCubic.Services
{
    public interface ICalculatorClient
    {
        Task<CalculationRequest> DownloadContentAsync(string path);
    }
}

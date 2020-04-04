using KoganCubic.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KoganCubic.Services
{
    public class CalculatorClient : ICalculatorClient
    {
        private readonly HttpClient httpClient;
        
        public CalculatorClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CalculationRequest> DownloadContentAsync(string downloadUrl)
        {
            var content = await httpClient.GetStringAsync(downloadUrl);
            CalculationRequest requestBody = JsonConvert.DeserializeObject<CalculationRequest>(content);
            return requestBody;
        }

    }
}

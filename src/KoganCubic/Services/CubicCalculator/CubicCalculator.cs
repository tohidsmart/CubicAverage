using KoganCubic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoganCubic.Services
{
    public class CubicCalculator : ICubicCalculator
    {
        public const int ConversionFactor = 250;
        private readonly ICalculatorClient client;
        private const string AirConditionerCategory = "Air Conditioners";

        public CubicCalculator(ICalculatorClient client)
        {
            this.client = client;
        }

        public async Task<CalculationResponse> GetAverageAsync()
        {
            var firstPage = "/api/products/1";
            var requestBody = await client.DownloadContentAsync(firstPage);
            var response = MassageData(requestBody);

            while (!string.IsNullOrEmpty(requestBody.Next))
            {
                requestBody = await client.DownloadContentAsync(requestBody.Next);
                var loopResponse = MassageData(requestBody);
                response.ParcelCount += loopResponse.ParcelCount;
                response.TotalParcelCount += loopResponse.TotalParcelCount;
                response.TotalValue += loopResponse.TotalValue;
            }

            response.Average = CalculateAverage(response);
            return response;
        }

        private decimal CalculateWeight(CubicParcel parcel)
        {
            CubicParcelSize size = parcel.Size;
            decimal? weight = (size.Height.Value / 100) * (size.Width.Value / 100) * (size.Length.Value / 100) * ConversionFactor;
            return weight ?? (default);
        }

        private decimal CalculateAverage(CalculationResponse response)
        {
            return response.TotalValue / response.ParcelCount;
        }

        private CalculationResponse MassageData(CalculationRequest requestBody)
        {
            var response = new CalculationResponse();
            var airConditionerParcels = requestBody.Objects.Where(parcel => parcel.Category == AirConditionerCategory);
            response.ParcelCount = airConditionerParcels.Count();
            response.TotalParcelCount = requestBody.Objects.Count();
            response.TotalValue = airConditionerParcels.Sum(parcel => CalculateWeight(parcel));
            response.Category = AirConditionerCategory;
            return response;
        }
    }
}

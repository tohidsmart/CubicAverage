using KoganCubic.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KoganCubic.Test
{
    public class CubicWeightTest
    {

        private readonly ICubicCalculator cubicCalculator;
        private readonly ICalculatorClient fakeCalculatorClient;
        private const string AirConditionerCategory = "Air Conditioners";

        public  CubicWeightTest()
        {
            fakeCalculatorClient = new FakeCalculatorClient();
            cubicCalculator = new CubicCalculator(fakeCalculatorClient);
        }
            
        [Fact]
        public async Task  A_GetFirstPage_FilterAirConditioners_CalculateAverageCubic()
        {
            //Arrange
            var sampleData = await fakeCalculatorClient.DownloadContentAsync("");
            
            //Act
            var response = await cubicCalculator.GetAverageAsync();
            var sampleDataObjects = sampleData.Objects;
            var sampleDataAirConditionerObject = sampleData.Objects.Where(obj => obj.Category == AirConditionerCategory);

            //Assert
            Assert.Equal(sampleDataAirConditionerObject.Count(), response.ParcelCount);
            Assert.Equal(sampleDataObjects.Count(), response.TotalParcelCount);
            Assert.Equal(43.55432M, response.TotalValue);
            Assert.Equal(43.55432M / sampleDataAirConditionerObject.Count(), response.Average);

        }
    }
}

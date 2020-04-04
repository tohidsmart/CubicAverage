using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoganCubic.Models;
using KoganCubic.Services;

namespace KoganCubic.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly ICubicCalculator calculator;

        public HomeController(ICubicCalculator calculator)
        {
            this.calculator= calculator;
        }

        public async Task<IActionResult> Calculate()
        {
            var response=await calculator.GetAverageAsync();
            return  View(response);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

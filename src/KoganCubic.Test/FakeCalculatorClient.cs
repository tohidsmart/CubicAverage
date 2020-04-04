using KoganCubic.Models;
using KoganCubic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoganCubic.Test
{
    public class FakeCalculatorClient : ICalculatorClient
    {
        public  Task<CalculationRequest> DownloadContentAsync(string path)
        {
           return  Task.FromResult( new CalculationRequest
            {
                Next = "",
                Objects = new List<CubicParcel>
                {
                    new CubicParcel
                    {
                        Category="Gadget",
                        Title="0 Pack Family Car Sticker Decals",
                        Size=new CubicParcelSize
                        {
                            Width=15.0M,
                            Length=13.0M,
                            Height=1.0M 
                        }
                    },
                    new CubicParcel
                    {
                        Category="Air Conditioners",
                        Title="Window Seal for Portable Air Conditioner Outlets",
                        Size=new CubicParcelSize
                        {
                            Width=26.0M,
                            Length=26.0M,
                            Height=5.0M
                        }
                    },
                    new CubicParcel
                    {
                        Category="Air Conditioners",
                        Title="Kogan 10,000 BTU Portable Air Conditioner (2.9KW)",
                        Size=new CubicParcelSize
                        {
                            Width=49.6M,
                            Length=38.7M,
                            Height=89.0M
                        }
                    }
                }
            });
        }
    }
}

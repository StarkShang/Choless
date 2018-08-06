using System;
using Choless.Core.Brands;

namespace Choless.Core.Commodities
{
    public class Cup : Commodity, IContainable
    {
        public double Capacity { get; set; }
        public string[] Matrial { get; set; }
    }
}

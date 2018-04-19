using System;
using Choless.Core.Brands;

namespace Choless.Core.Commodities
{
    public class Cup : IContainable
    {
        public virtual Brand Brand { get; set; }
        public double Capacity { get; set; }
        public string[] Matrial { get; set; }
    }
}

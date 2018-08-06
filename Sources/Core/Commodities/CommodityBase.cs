using Choless.Core;
using Choless.Core.Brands;

namespace Choless.Core.Commodities
{
    public abstract class Commodity
    {
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}

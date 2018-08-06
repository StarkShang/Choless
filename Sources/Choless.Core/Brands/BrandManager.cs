using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Choless.Core.Managers;
using Microsoft.EntityFrameworkCore;

namespace Choless.Core.Brands
{
    public class BrandManager : DbContextBase
    {
        public DbSet<Brand> Brands { get; set; }

        public async Task<bool> CreateBrand(Brand brand)
        {
            var a = Brands.Add(brand);
            var num = await SaveChangesAsync();
            return false;
        }

        public IEnumerable<Brand> QueryBrandsByCommodityClass(string commodityClass)
        {
            var brands = from brand in Brands.Include(b => b.BusinessScopes).Include(b => b.Headquarters)
                         from scope in brand.BusinessScopes
                         where scope.CommodityClass == commodityClass
                         select brand;

            return brands;
        }

        #region Constructor
        public BrandManager(string connectionString) : base(connectionString) { }
        #endregion
    }
}

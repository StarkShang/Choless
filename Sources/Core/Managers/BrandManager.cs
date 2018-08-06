using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Choless.Core.Brands;
using Choless.Core.Database;
using MongoDB.Driver;

namespace Choless.Core.Managers
{
    public class BrandManager
    {
        private IMongoCollection<Brand> _database = DatabaseHelper.BrandDatabase;

        public async Task<IEnumerable<Brand>> GetBrandsAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> AnonymousCreateBrandAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> GetBrandByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> DeleteBrandByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> ModifyBrandByIdAsync(int id, Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> ReplaceBrandByIdAsync(int id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
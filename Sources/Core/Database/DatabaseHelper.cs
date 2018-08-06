using Choless.Core.Brands;
using Choless.Core.Commodities;
using Choless.Core.Commons;
using MongoDB.Driver;

namespace Choless.Core.Database
{
    internal class DatabaseHelper
    {
        public static IMongoCollection<Brand> BrandDatabase { get {
            return new MongoClient()
                .GetDatabase(Configuration.DatabaseName)
                .GetCollection<Brand>("brand");
        }}
        public static IMongoCollection<Commodity> CommodityDatabase { get {
            return new MongoClient()
                .GetDatabase(Configuration.DatabaseName)
                .GetCollection<Commodity>("commodities");
        }}
    }
}
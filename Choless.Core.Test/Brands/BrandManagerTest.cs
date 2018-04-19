using System;
using System.Linq;
using Choless.Core.Brands;
using Choless.Core.Tools;
using Choless.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Brands
{
    [TestClass]
    public class BrandManagerTest
    {
        const string DatabaseName = "choless";
        [TestMethod]
        public void TestGetBrandsByCommodityClass()
        {
            var scope = new BusinessScope { CommodityClass = "Information Platform" };
            var brand = new Brand
            {
                BrandId = "00000000000000000000000000000001",
                BrandName = "Choless",
                BusinessScopes = new BusinessScope[] { scope },
                WebSite = "www.choless.com",
                Headquarters = new Headquarters
                {
                    HeadquartersId = "headquarters id",
                    Country = "China",
                    Province = "Shanghai",
                    City = "Shanghai",
                    Address = "No. 800 Dongchuan Road"
                },
                EstablishedTime = new DateTime(2018, 3, 30),
                Description = "A company to make less choices."
            };
            scope.Brand = brand;
            // Run the test against one instance of the context
            using (var manager = new BrandManager(DatabaseName))
            {
                Console.WriteLine(manager.Database.ProviderName);
                manager.Brands.Add(brand);
                manager.SaveChanges();
            }
            // Use a separate instance of the context to verify correct data was saved to database
            using (var manager = new BrandManager(DatabaseName))
            {
                Console.WriteLine(manager.Database.ProviderName);
                var query = manager.QueryBrandsByCommodityClass("Information Platform");

                Assert.AreEqual(1, query.Count());
                Assert.AreEqual(brand, query.First());
            }


        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            EnvironmentTool.SetEnviroment("Test");
        }
    }
}

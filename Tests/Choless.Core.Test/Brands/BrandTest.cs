using System;
using System.Collections.Generic;
using System.Linq;
using Choless.Core.Brands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Brands
{
    [TestClass]
    public class BrandTest
    {
        static Brand brand;

        [TestMethod]
        public void TestClone()
        {
            var b = brand.Clone();
            foreach (var property in b.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(brand), property.GetValue(b));
            }
        }

        [TestMethod]
        public void TestEqualsPass()
        {
            var b = brand.Clone() as Brand;
            var scopes = new List<BusinessScope>();
            foreach (var scope in brand.BusinessScopes)
            {
                scopes.Add(scope.Clone() as BusinessScope);
            }
            var headquarters = brand.Headquarters.Clone();

            Assert.AreEqual(brand, b);
        }

        [TestMethod]
        public void TestEqualsNotPass()
        {
        }

        [ClassInitialize]
        public static void ClassInitializa(TestContext context)
        {
            var scope = new BusinessScope
            {
                BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000001",
                CommodityClass = "Information Platform",
            };
            brand = new Brand
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
        }

    }
}

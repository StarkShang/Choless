using System;
using System.Collections.Generic;
using Choless.Core.Brands;
using Choless.Core.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Tools
{
    [TestClass]
    public class TestDataLoaderTest
    {
        [TestMethod]
        public void TestLoadData()
        {
            var data = TestDataLoader.LoadData<Brand>();
            Assert.IsInstanceOfType(data, typeof(IEnumerable<Brand>));
        }

        [TestMethod]
        public void TestSaveData()
        {
            var headquarters = new Headquarters
            {
                HeadquartersId = "",
                Country = "China",
                Province = "Shanghai",
                City = "Shanghai",
                Address = "No. 800 Dongchuan Road"
            };
            var brand = new Brand
            {
                BrandId = "00000000000000000000000000000001",
                BrandName = "Choless",
                WebSite = "www.choless.com",
                Headquarters = headquarters,
                EstablishedTime = new DateTime(2018, 3, 3, 12, 12, 0),
                Description = "A company to make less choices."
            };
            TestDataLoader.SaveData(brand);
            Assert.Fail();
        }
    }
}

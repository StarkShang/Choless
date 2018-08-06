using System;
using Choless.Core.Brands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Brands
{
    [TestClass]
    public class HeadquartersTest
    {
        static Headquarters headquarters;

        [TestMethod]
        public void TestClone()
        {
            var h = headquarters.Clone();

            Assert.AreEqual(headquarters, h);
            Assert.AreNotSame(headquarters, h); 
        }

        [TestMethod]
        public void TestEqualsPass()
        {
            var h1 = headquarters.Clone();

            Assert.AreEqual(headquarters, h1);
        }

        [TestMethod]
        public void TestEqualsNotPass()
        {
            var h1 = headquarters.Clone() as Headquarters;
            h1.HeadquartersId = "headquarters";

            Assert.AreNotEqual(headquarters, h1);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            headquarters = new Headquarters
            {
                HeadquartersId = "headquarters id",
                Country = "China",
                Province = "Shanghai",
                City = "Shanghai",
                Address = "No. 800 Dongchuan Road"
            };
        }

    }
}

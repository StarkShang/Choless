using System;
using System.Collections.Generic;
using System.Linq;
using Choless.Core.Brands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Brands
{
    [TestClass]
    public class BusinessScopeTest
    {
        static BusinessScope scope;

        [TestMethod]
        public void TestClone()
        {
            var s = scope.Clone();

            Assert.AreEqual(scope, s);
            Assert.AreNotSame(scope, s);
        }

        [TestMethod]
        public void TestEqualsPass()
        {
            var s = scope.Clone();

            Assert.AreEqual(scope, s);
        }

        [TestMethod]
        public void TestEqualsNotPass()
        {
            var s = scope.Clone() as BusinessScope;
            s.Brand = null;

            Assert.AreNotEqual(scope, s);
        }

        [TestMethod]
        public void TestIEnumerableEqualsPass()
        {
            var s1 = scope.Clone() as BusinessScope;
            s1.BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000001";
            var s2 = scope.Clone() as BusinessScope;
            s2.BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000002";

            IEnumerable<BusinessScope> i1 = new List<BusinessScope> { s1, s2 };
            IEnumerable<BusinessScope> i2 = new List<BusinessScope> { s1, s2 };

            i1 = i1.OrderBy(x => x.BusinessScopeId);
            i2 = i2.OrderBy(x => x.BusinessScopeId);
            Assert.AreEqual(true, i1.SequenceEqual(i2));
        }

        [TestMethod]
        public void TestIEnumerableEqualsNotPass()
        {
            var s1 = scope.Clone() as BusinessScope;
            s1.BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000001";
            var s2 = scope.Clone() as BusinessScope;
            s2.BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000002";

            IEnumerable<BusinessScope> i1 = new List<BusinessScope> { s1, s2 };
            IEnumerable<BusinessScope> i2 = new List<BusinessScope> { s2 };

            i1 = i1.OrderBy(x => x.BusinessScopeId);
            i2 = i2.OrderBy(x => x.BusinessScopeId);
            Assert.AreEqual(false, i1.SequenceEqual(i2));
        }


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var brand = new Brand();
            scope = new BusinessScope()
            {
                BusinessScopeId = "0000000000000000000000000000000000000000000000000000000000000001",
                Brand = brand,
                CommodityClass = "Information Platform"
            };
        }

    }
}

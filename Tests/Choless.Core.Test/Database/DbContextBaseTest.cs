using System;
using System.Linq;
using Choless.Core.Brands;
using Choless.Core.Managers;
using Choless.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Database
{
    [TestClass]
    public class DbContextBaseTest
    {
        [DataTestMethod]
        [DataRow("Test", "Microsoft.EntityFrameworkCore.InMemory")]
        [DataRow("Development", "MySql.Data.EntityFrameworkCore")]
        [DataRow("Release","MySql.Data.EntityFrameworkCore")]
        public void TestOnConfiguring(string environmentName, string databaseName)
        {
            Environment.SetEnvironmentVariable("DOTNETCORE_ENVIRONMENT", environmentName);
            using(var context = new TestDbContext("test"))
            {
                Assert.AreEqual(databaseName, context.Database.ProviderName);
            }
        }
    }

    internal class TestDbContext : DbContextBase
    {
        public TestDbContext(string connectionString) : base(connectionString)
        {
        }
    }
}

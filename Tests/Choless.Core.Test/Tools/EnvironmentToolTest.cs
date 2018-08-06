using System;
using Choless.Core.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Choless.Core.Test.Tools
{
    [TestClass]
    public class EnvironmentToolTest
    {
        [TestMethod]
        public void TestIsTestEnvironment()
        {
            EnvironmentTool.SetEnviroment("Test");
            Assert.IsTrue(EnvironmentTool.IsTestEnvironment);
            Assert.IsFalse(EnvironmentTool.IsDevelopmentEnvironment);
            Assert.IsFalse(EnvironmentTool.IsReleassEnvironment);
        }

        [TestMethod]
        public void TestIsDevelopmentEnvironment()
        {
            EnvironmentTool.SetEnviroment("Development");
            Assert.IsFalse(EnvironmentTool.IsTestEnvironment);
            Assert.IsTrue(EnvironmentTool.IsDevelopmentEnvironment);
            Assert.IsFalse(EnvironmentTool.IsReleassEnvironment);
        }

        [TestMethod]
        public void TestIsReleassEnvironment()
        {
            EnvironmentTool.SetEnviroment("Release");
            Assert.IsFalse(EnvironmentTool.IsTestEnvironment);
            Assert.IsFalse(EnvironmentTool.IsDevelopmentEnvironment);
            Assert.IsTrue(EnvironmentTool.IsReleassEnvironment);
        }

        [DataTestMethod]
        [DataRow("Test")]
        [DataRow("Development")]
        [DataRow("Release")]
        public void TestSetEnviroment(string environment)
        {
            EnvironmentTool.SetEnviroment(environment);
            var e = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
            Assert.AreEqual(environment, e);
        }
    }
}

using System;
using System.IO;
using Choless.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace Choless.Core.Test.Utilities
{
    [TestClass]
    public class NLoggerTest
    {
        private static NLogger logger;
        private static DebugTarget target;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestDebugPass()
        {
            var message = TestContext.TestName;
            logger.Debug(new Exception(), $"{message}", null);
            Assert.AreEqual($"Debug|{message}", target.LastMessage);
        }

        [TestMethod]
        public void TestErrorPass()
        {
            var message = TestContext.TestName;
            logger.Error(new Exception(), $"{message}", null);
            Assert.AreEqual($"Error|{message}", target.LastMessage);
        }

        [TestMethod]
        public void TestFatalPass()
        {
            var message = TestContext.TestName;
            logger.Fatal(new Exception(), $"{message}", null);
            Assert.AreEqual($"Fatal|{message}", target.LastMessage);
        }

        [TestMethod]
        public void TestInfoPass()
        {
            var message = TestContext.TestName;
            logger.Info(new Exception(), $"{message}", null);
            Assert.AreEqual($"Info|{message}", target.LastMessage);
        }

        [TestMethod]
        public void TestTracePass()
        {
            var message = TestContext.TestName;
            logger.Trace(new Exception(), $"{message}", null);
            Assert.AreEqual($"Trace|{message}", target.LastMessage);
        }

        [TestMethod]
        public void TestWarnPass()
        {
            var message = TestContext.TestName;
            logger.Warn(new Exception(), $"{message}", null);
            Assert.AreEqual($"Warn|{message}", target.LastMessage);
        }


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var config = LogManager.Configuration;
            target = config.FindTargetByName("unitTest") as DebugTarget;
            logger = new NLogger();

        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            logger = null;
            target = null;
        }
    }
}

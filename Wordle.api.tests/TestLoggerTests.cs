using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.api.tests
{
    [TestClass]
    public class TestLoggerTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            TestLogger<object> logger = new();
            logger.Log("Test 0-1");
            using (logger.BeginScope("Scope 1"))
            {
                logger.Log("Test 1-1");
                using (logger.BeginScope("Scope 2"))
                {
                    logger.Log("Test 1-2-1");
                }
                logger.Log("Test 1-2");
            }
            logger.Log("Test 0-2");
            Assert.AreEqual(5, logger.LogEntries.Count);
            Assert.AreEqual("Debug: Root: Test 0-1", logger.LogEntries[0]);
            Assert.AreEqual("Debug: Scope 2->Scope 1: Test 1-2-1", logger.LogEntries[2]);
            Assert.AreEqual("Debug: Root: Test 0-2", logger.LogEntries[4]);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Controllers;
using Wordle.Api;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class LeaderBoardIntegrationTests: IntegrationTestBase
    {
        /// <summary>
        /// test the controller with integration test harness
        /// </summary>
        [TestMethod]
        public async Task Get()
        {
            var response = await Client.GetAsync("/leaderboard");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Contains("Hildegaard"));
        }

    }
}

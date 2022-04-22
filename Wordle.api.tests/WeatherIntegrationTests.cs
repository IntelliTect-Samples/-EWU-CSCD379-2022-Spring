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
    public class WeatherIntegrationTests: IntegrationTestBase
    {
        /// <summary>
        /// test the controller with integration test harness
        /// </summary>
        [TestMethod]
        public async Task WeatherGet()
        {
            var response = await Client.GetAsync("/weather");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Length > 10);
        }
    }
}

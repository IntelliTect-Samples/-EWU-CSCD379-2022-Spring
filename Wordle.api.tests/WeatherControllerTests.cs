using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Controllers;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            var logger = new TestLogger<WeatherForecastController>();
            WeatherForecastController sut = new(logger);
            Assert.AreEqual(5,sut.Get().Count());
        }
    }
}
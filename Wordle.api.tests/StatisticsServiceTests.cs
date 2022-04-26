using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Controllers;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class StatisticsServiceTests:DatabaseTestBase
    {
        private readonly StatisticsService _sut;

        public StatisticsServiceTests()
        {
            StatisticsService.Seed(Db);
            _sut = new(Db);
        }

        [TestMethod]
        public void GetScores()
        {
            var result  = _sut.GetScores();
            Assert.AreEqual(6, result.Count());
        }
    }
}
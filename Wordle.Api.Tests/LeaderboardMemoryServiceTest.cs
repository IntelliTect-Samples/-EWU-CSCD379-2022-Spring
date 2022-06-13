using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class LeaderboardMemoryServiceTest
    {
        [TestMethod]
        public void GetScores()
        {
            LeaderboardServiceMemory service = new();

            Assert.AreEqual(3, service.GetScores().Count());
            Assert.AreEqual("Hildagaurd", service.GetScores().First().Name);
            Assert.AreEqual("Gene", service.GetScores().Last().Name);
            Assert.AreEqual(3, service.GetScores().Count());
        }

        [TestMethod]
        public void AddScore_AddsNewPlayer()
        {
            LeaderboardServiceMemory service = new();
            service.AddScore(new GameScore(5, "Gene"));
            Assert.AreEqual(3.4, service.GetScores().First(x => x.Name == "Ralph").AverageGuesses);
        }

        [TestMethod]
        public void AddScore_UpdatesExistingPlayer()
        {
            LeaderboardServiceMemory service = new();
            service.AddScore(new GameScore(5, "Ralph"));
            Assert.AreEqual(31, service.GetScores().First(x => x.Name == "Ralph").NumberGames);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class PlayerWordServiceTests : DatabaseTestBase
    {
        public PlayerWordServiceTests() : base() { }

        private static readonly string _playerName = "Inigo";
        private static readonly string _word = "WORDS";

        [TestMethod]
        public async Task PlayerWord1Start()
        {
            var sut = new PlayerWordService(_context);

            var playerWord = await sut.Start(_playerName, _word);

            Assert.IsNotNull(playerWord);
            Assert.IsNotNull(playerWord.Word);
            Assert.IsNotNull(playerWord.Player);
        }

        [TestMethod]
        public async Task PlayerWord2StartAgain()
        {
            var sut = new PlayerWordService(_context);

            var playerWordInitial = _context.PlayerWords
                .First(f => f.Player.Name == _playerName && f.Word.Letters == _word && f.State == PlayerWord.PlayerWordState.Guessing);

            var playerWord = await sut.Start(_playerName, _word);

            Assert.AreEqual(playerWordInitial.PlayerWordId, playerWord.PlayerWordId);
        }

        [TestMethod]
        public async Task PlayerWord3Guess1()
        {
            var sut = new PlayerWordService(_context);
            var playerWord = await sut.Start(_playerName, _word);
            
            var result = await sut.Guess(playerWord.PlayerWordId, "GUESS");
            
            Assert.IsFalse(result);
            Assert.AreEqual(1, sut.GetPlayerWords(_playerName, _word).First(f => f.PlayerWordId == playerWord.PlayerWordId).Guesses.Count);

        }

        [TestMethod]
        public async Task PlayerWord4Guess2()
        {
            var sut = new PlayerWordService(_context);
            var playerWord = await sut.Start(_playerName, _word);

            var result = await sut.Guess(playerWord.PlayerWordId, "AMAZE");

            Assert.IsFalse(result);
            Assert.AreEqual(2, sut.GetPlayerWords(_playerName, _word).First(f => f.PlayerWordId == playerWord.PlayerWordId).Guesses.Count);

        }


        [TestMethod]
        public async Task PlayerWord9Win()
        {
            var sut = new PlayerWordService(_context);

            var playerWord = await sut.Start(_playerName, _word);
            var done = await sut.Guess(playerWord.PlayerWordId, _word);

            Assert.IsTrue(done);
            Assert.AreEqual(3, sut.GetPlayerWords(_playerName, _word).First(f => f.PlayerWordId == playerWord.PlayerWordId).Guesses.Count);

            var playerWordInitial = _context.PlayerWords
                .First(f => f.Player.Name == _playerName && f.Word.Letters == _word);
            
            Assert.AreEqual(PlayerWord.PlayerWordState.Won, playerWordInitial.State);

        }

        /// <summary>
        /// Make sure that all active tests get marked as abandoned so that next time we don't see these.
        /// </summary>
        /// <returns></returns>
        [ClassCleanup]
        public static async Task ClassCleanup()
        {
            var context = GetContext();
            // Make sure there aren't any open games
            foreach (var pw in context.PlayerWords.Where(f => f.State == PlayerWord.PlayerWordState.Guessing))
            {
                pw.State = PlayerWord.PlayerWordState.Abandoned;
            }
            await context.SaveChangesAsync();

        }

    }
}

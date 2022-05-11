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
    public class PlayerServiceTests
    {
        PlayerService sut;
        bool migrated = false;
        [TestInitialize]
        public void setup()
        {
            if (!migrated)
            {
                var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests.PlayerService;Trusted_Connection=True;MultipleActiveResultSets=true");
                AppDbContext context = new AppDbContext(contextOptions.Options);
                context.Database.Migrate();
                PlayerService.Seed(context);

                sut = new PlayerService(context);

                migrated = true;

            }
        }

        [TestMethod]
        public void PlayerService_CanUpdate()
        {
            sut.Update("Flint", 4, 120);

        }

        [TestMethod]
        public void PlayerService_UpdateCalculatesAverageAttempts()
        {
            Player Flint = sut.GetPlayers().Where(e => e.Name.Equals("Flint")).First();
            double nextAverageAttempts = Flint.AverageAttempts + ((1-Flint.AverageAttempts)/(Flint.GameCount+1));
            sut.Update("Flint", 1, 120);
            Assert.AreEqual<double>(nextAverageAttempts, Flint.AverageAttempts);
        }

        [TestMethod]
        public void PlayerService_UpdateCalculatesAverageSeconds()
        {
            Player Flint = sut.GetPlayers().Where(e => e.Name.Equals("Flint")).First();
            int nextAverageSeconds = Flint.AverageSecondsPerGame + ((700 - Flint.AverageSecondsPerGame) / (Flint.GameCount + 1));
            sut.Update("Flint", 1, 700);
            Assert.AreEqual<double>(nextAverageSeconds, Flint.AverageSecondsPerGame);
        }

        [TestMethod]
        public void PlayerService_UpdateAddsNewPlayer()
        {
            string name = "";
            Random rng = new();
            //Generate random name
            do
                name += rng.Next(10);
            while (sut.GetPlayers().Where(e => e.Name.Equals(name)).FirstOrDefault() is not null);

            int oldCount = sut.GetPlayers().Count();
            sut.Update(name, 3, 3);

            Assert.AreEqual<int>(oldCount + 1, sut.GetPlayers().Count());
            Assert.AreEqual<int>(1, sut.GetPlayers().Where(e=>e.Name.Equals(name)).First().GameCount);
            Assert.AreEqual<double>(3, sut.GetPlayers().Where(e=>e.Name.Equals(name)).First().AverageAttempts);
            Assert.AreEqual<int>(3, sut.GetPlayers().Where(e=>e.Name.Equals(name)).First().AverageSecondsPerGame);
        }

        [TestMethod]
        public void PlayerService_UpdateIncrementsGame()
        {
            Player firstPlayer = sut.GetPlayers().First();
            int oldGameCount = firstPlayer.GameCount;

            sut.Update(firstPlayer.Name, 5, 72);

            Assert.AreEqual<int>(oldGameCount + 1, sut.GetPlayers().Where(e => e.Name.Equals(firstPlayer.Name)).First().GameCount); //Might seem redundant, but update could change the first player!

        }

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class PlayerServiceTests
{
    private AppDbContext _context;
    private PlayerService service;

    [TestInitialize]
    public void testInit()
    {
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
        _context = new AppDbContext(contextOptions.Options);
        _context.Database.Migrate();

        service = new PlayerService(_context);

        _context.Players.Add(new Player()
        {
            Name = "Kelsey",
            GameCount = 10,
            AverageAttempts = 2.3
        });

        _context.Players.Add(new Player()
        {
            Name = "Leona",
            GameCount = 5,
            AverageAttempts = 3.0
        });

        _context.Players.Add(new Player()
        {
            Name = "Gray",
            GameCount = 3,
            AverageAttempts = 4.0
        });

        _context.SaveChanges();
    }

    [TestCleanup]
    public void testClean()
    {
        _context.Players.Remove(service.GetPlayers().First(x => x.Name == "Kelsey"));
        _context.Players.Remove(service.GetPlayers().First(x => x.Name == "Gray"));
        _context.Players.Remove(service.GetPlayers().First(x => x.Name == "Leona"));

        _context.SaveChanges();
    }

    [TestMethod]
    public void GetPlayers()
    {
        Assert.AreEqual(3, service.GetPlayers().Count());
    }

    [TestMethod]
    public void Update_AddsNewPlayer()
    {
        Player player = service.GetPlayers().First(x => x.Name == "Kelsey").Clone();

        //double newAverage = Math.Round(player.AverageAttempts + 5 / player.GameCount++, 2);
        service.Update("Kelsey", 1, 5);

        Assert.AreEqual(player.GameCount + 1, service.GetPlayers().First(x => x.Name == "Kelsey").GameCount);
        Assert.AreEqual(2.75, service.GetPlayers().First(x => x.Name == "Kelsey").AverageAttempts);
    }

    [TestMethod]
    public void Update_UpdatesCurrentPlayer()
    {

    }
}


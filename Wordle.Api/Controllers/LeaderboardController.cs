using Microsoft.AspNetCore.Mvc;
using Wordle.api.Services;

namespace Wordle.api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController
{
    private readonly ILogger<LeaderboardController> _logger;
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILogger<LeaderboardController> logger,
        ILeaderboardService leaderboardService)
    {
        _logger = logger;
        _leaderboardService = leaderboardService;
    }

    [HttpGet]
    public IEnumerable<Score> Get(string name)
    {
        _logger.LogInformation("LeaderboardController.Get()");

        //List<Score> results = new()
        //{
        //    new Score("Hildagaurd", 25, 2.6),
        //    new Score("Ralph", 30, 3.4),
        //    new Score("Gene", 50, 4.1),
        //};

        List<Score> results = _leaderboardService.GetScores().ToList();

        return results;
    }

    [HttpPost]
    public void Post([FromBody] GameScore score)
    {
        _logger.LogInformation("LeaderboardController.Post()");
        _leaderboardService.AddScore(score);
    }

}


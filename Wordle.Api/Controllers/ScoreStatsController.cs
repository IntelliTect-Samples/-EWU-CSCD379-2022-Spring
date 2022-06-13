using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.api.Services;
using Wordle.api.Data;

namespace Wordle.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScoreStatsController : ControllerBase
{
    private readonly ScoreStatsService _service;

    //Get the ScoreStatService in the constructor
    public ScoreStatsController(ScoreStatsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<ScoreStat> Get()
    {
        return _service.GetScoreStats();
    }

    //Whenever you are doing a post, it must take in an object of the items you want to post
    //You must return something to the browser (200 OK!) 
    [HttpPost]
    public IActionResult Post([FromBody] ScoreStatPost score)
    {
        _service.Update(score.Score, score.Seconds);
        return Ok();
    }

    //Create a local nested class to use in the Post since it only takes objects
    //This will be used to populate the properties in our ScoreStatService object
    public class ScoreStatPost
    {
        public int Score { get; set; }
        public int Seconds { get; set; }
    }
}


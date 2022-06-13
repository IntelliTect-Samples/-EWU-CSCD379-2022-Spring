using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.api.Services;
using Wordle.api.Data;

namespace Wordle.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _service;

    //Get the ScoreStatService in the constructor
    public PlayerController(PlayerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Player> Get()
    {
        return _service.GetPlayers();
    }

    //Whenever you are doing a post, it must take in an object of the items you want to post
    //You must return something to the browser (200 OK!) 
    [HttpPost]
    public IActionResult Post([FromBody] PlayerPost player)
    {
        _service.Update(player.Name, player.GameCount, player.AverageAttempts);
        return Ok();
    }

    //Create a local nested class to use in the Post since it only takes objects
    //This will be used to populate the properties in our ScoreStatService object
    public class PlayerPost
    {
        public string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
    }
}


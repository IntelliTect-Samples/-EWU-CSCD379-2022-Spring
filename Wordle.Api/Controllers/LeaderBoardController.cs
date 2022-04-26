using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("LeaderBoard")]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILogger<LeaderBoardController> _logger;
        private readonly ILeaderBoardService _leaderBoardService;
        
        public LeaderBoardController(ILogger<LeaderBoardController> logger, ILeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet()]
        public IEnumerable<Score> Get()
        {
            _logger.LogInformation("Get LeaderBoard");
            return _leaderBoardService.GetHighScores();
        }

        [HttpPost("SubmitScore")]
        [Authorize()]
        public ActionResult<Score> SubmitScore([FromBody] NewScore newScore)
        {
            try
            {
                return Ok(_leaderBoardService.UpdateScore(newScore.Name, newScore.NumberOfAttempts));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class NewScore
        {
            public string Name { get; set; } = "";
            public int NumberOfAttempts { get; set; } = 0;
        }
    }
}
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

        [HttpPost()]
        [Authorize()]
        public Score SubmitScore(string name, int numberOfAttempts)
        {
            return _leaderBoardService.UpdateScore(name, numberOfAttempts);
        }
    }
}
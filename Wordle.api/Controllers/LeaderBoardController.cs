using Microsoft.AspNetCore.Mvc;
using Wordle.api.Services;

namespace Wordle.api.Controllers
{
    [ApiController]
    [Route("LeaderBoard")]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILogger<LeaderBoardController> _logger;
        private readonly LeaderBoardService _leaderBoardService;
        
        public LeaderBoardController(ILogger<LeaderBoardController> logger, LeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet()]
        public IEnumerable<LeaderBoardService.Score> Get()
        {
            return _leaderBoardService.GetHighScores();
        }

    }
}
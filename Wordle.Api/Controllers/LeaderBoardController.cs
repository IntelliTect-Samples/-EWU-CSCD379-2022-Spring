﻿using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController
    {
        private readonly ILogger<LeaderBoardController> _logger;
        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILogger<LeaderBoardController> logger,
            ILeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet]
        public IEnumerable<Score> Get()
        {
            _logger.LogInformation("LeaderBoardController.Get()");
            return _leaderBoardService.GetScores();
        }
        
        [HttpPost]
        public void Post([FromBody] GameScore score)
        {
            _logger.LogInformation("LeaderBoardController.Post()");
            _leaderBoardService.AddScore(score);
        }



    }
}

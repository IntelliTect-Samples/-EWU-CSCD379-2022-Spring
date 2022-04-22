﻿namespace Wordle.Api.Services
{
    public class LeaderBoardService
    {
        private readonly ILogger<LeaderBoardService> _logger;
        public LeaderBoardService(ILogger<LeaderBoardService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Score> GetHighScores()
        {
            _logger.Log(LogLevel.Information, "Getting high scores");
            return new List<Score>
            {
                new Score("Bubba", 3.4, 10),
                new Score("Hildegaard", 2.5, 8),
                new Score("Brunhilde", 4.2, 20),
            };
        }

        public class Score
        {
            public string Name { get; set; }
            public double Average { get; set; }
            public int GameCount { get; set; }

            public Score(string name, double average, int gameCount)
            {
                Name = name;
                Average = average;
                GameCount = gameCount;
            }
        }
    }
}

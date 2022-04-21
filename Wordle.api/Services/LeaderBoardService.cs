namespace Wordle.api.Services
{
    public class LeaderBoardService: ILeaderBoardService
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
    }
}

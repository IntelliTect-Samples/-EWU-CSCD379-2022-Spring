namespace Wordle.Api.Services
{
    public class LeaderBoardService: ILeaderBoardService
    {
        private readonly ILogger<LeaderBoardService> _logger;

        private static IEnumerable<Score> _highScores = new List<Score> {
            new Score("Bubba", 3.4, 10),
            new Score("Hildegaard", 2.5, 8),
            new Score("Brunhilde", 4.2, 20)
        };

        public LeaderBoardService(ILogger<LeaderBoardService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Score> GetHighScores()
        {
            _logger.Log(LogLevel.Information, "Getting high scores");
            return _highScores;
        }

        public Score UpdateScore(string name, int numberOfAttempts)
        {
            if (numberOfAttempts < 1 || numberOfAttempts > 5) throw new ArgumentException("Number of Attempts out of range");
            var score = _highScores.FirstOrDefault(f => f.Name == name);
            if (score == null) throw new ArgumentException("Name not found");
            score.Average = (score.Average * score.GameCount++ + numberOfAttempts) / score.GameCount;
            return score;
        }
    }
}

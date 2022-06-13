namespace Wordle.api.Services;

public class LeaderboardServiceMemory : ILeaderboardService
{
    private static readonly List<Score> _scores = new();

    public LeaderboardServiceMemory()
    {
        if (!_scores.Any())
        {
            List<Score> results = new();

            _scores.Add(new Score("Ralph", 30, 3.4));
            _scores.Add(new Score("Gene", 50, 4.1));
            _scores.Add(new Score("Hildagaurd", 25, 2.6));
        };
    }

    public void AddScore(GameScore gameScore)
    {
        var score = _scores.FirstOrDefault(f => f.Name == gameScore.Name);

        if (score is not null)
        {
            score.AverageGuesses = ((score.NumberGames * score.AverageGuesses)
                    + gameScore.Score) / ++score.NumberGames;
        }
        else
        {
            //_scores.Add(new Score(gameScore.Name, gameScore.Score., ));
        }
    }

    public IEnumerable<Score> GetScores()
    {
        return _scores.OrderBy(x => x.NumberGames);
    }
}




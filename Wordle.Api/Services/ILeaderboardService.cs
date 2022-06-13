namespace Wordle.api.Services;

public interface ILeaderboardService
{
    IEnumerable<Score> GetScores();
    void AddScore(GameScore score);
}



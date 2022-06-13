namespace Wordle.Api.Services;

public interface ILeaderboardService
{
    IEnumerable<Score> GetScores();
    void AddScore(GameScore score);
}



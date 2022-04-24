namespace Wordle.Api.Services
{
    public interface ILeaderBoardService
    {
        IEnumerable<Score> GetHighScores();
        Score UpdateScore(string name, int numberOfAttempts);
    }
}

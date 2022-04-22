namespace Wordle.Api.Services
{
    public interface ILeaderBoardService
    {
        IEnumerable<Score> GetHighScores();
    }
}

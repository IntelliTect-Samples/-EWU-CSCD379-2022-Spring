using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class StatisticsService
    {
        public StatisticsService(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;

        public async Task AddScore(int score, int seconds)
        {
            var scoreStat = _db.ScoreStats.FirstOrDefault(f => f.Score == score);
            if (scoreStat != null)
            {
                scoreStat.TotalGames++;
                scoreStat.TotalSeconds += seconds;
            }
            await _db.SaveChangesAsync();
        }

        public IEnumerable<ScoreStat> GetScores()
        {
            return _db.ScoreStats.OrderBy(f => f.Score);
        }

        public int TotalSeconds()
        {
            return _db.ScoreStats.Sum(f => f.TotalSeconds);
        }

        public int TotalGames()
        {
            return _db.ScoreStats.Sum(f => f.TotalGames);
        }

        public static void Seed(AppDbContext db)
        {
            if (!db.ScoreStats.Any())
            {
                for(int score = 1; score <= 6; score++)
                {
                    var scoreStat = new ScoreStat { Score = score, TotalGames = 0, TotalSeconds = 0 };
                    db.ScoreStats.Add(scoreStat);
                }
                db.SaveChanges();
            }
        }
    }
}

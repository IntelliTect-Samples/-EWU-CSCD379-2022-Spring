using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class ScoreStat
    {
        public int ScoreStatId { get; set; }

        /// <summary>
        /// A record for each Score
        /// </summary>
        public int Score { get; set; } = 0;
        /// <summary>
        /// Total number of games won with this score
        /// </summary>
        public int TotalGames { get; set; } = 0;

        public int TotalSeconds { get; set; } = 0;
    }
}

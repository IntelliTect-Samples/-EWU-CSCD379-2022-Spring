using System.ComponentModel.DataAnnotations;

namespace Wordle.api.Data;

public class ScoreStat
{
    //As long as the last char of the key below end in ID
    //it defaults to a primary key
    [Key]
    public int ScoreStatID { get; set; }
    public int Score { get; set; }
    public int AverageSeconds { get; set; }
    public int TotalGames { get; set; }

    public ScoreStat Clone()
    {
        return new ScoreStat
        {
            ScoreStatID = ScoreStatID,
            Score = Score,
            AverageSeconds = AverageSeconds,
            TotalGames = TotalGames,
        };
    }
}

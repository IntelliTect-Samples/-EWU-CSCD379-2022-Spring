using System.ComponentModel.DataAnnotations;

namespace Wordle.api.Data;
public class Player
{
    [Key]
    public int PlayerID { get; set; }
    public string Name { get; set; } = null!;
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }

    public Player Clone()
    {
        return new Player
        {
            PlayerID = PlayerID,
            Name = Name,
            GameCount = GameCount,
            AverageAttempts = AverageAttempts,
        };
    }
}


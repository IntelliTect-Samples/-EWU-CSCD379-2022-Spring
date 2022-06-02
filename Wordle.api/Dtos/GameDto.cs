using Wordle.api.Data;

namespace Wordle.api.Dtos;
public class GameDto
{
    public string Word { get; set; }
    public int GameId { get; set; }
    public bool WasPlayed { get; set; }

    public GameDto(Game game)
    {
        Word = game.Word.Value;
        GameId = game.GameId;
        WasPlayed = game.DateEnded.HasValue;
    }
}


get; set; }

        public GameDto(Game game)
        {
            Word = game.Word.Value;
            GameId = game.GameId;
            WasPlayed = game.DateEnded.HasValue;
            Guesses = game.Guesses.Select(x=>x.Value);
            StartDate = game.DateStarted;
            GuessesCsv = string.Join(",", game.Guesses.Select(x => x.Value));
        }
    }
}

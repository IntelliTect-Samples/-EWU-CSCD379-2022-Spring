namespace Wordle.Api.Data
{
    public class PlayerWordGuess
    {
        public int PlayerWordGuessId { get; set; }
        public int PlayerWordId { get; set; }
        public PlayerWord PlayerWord { get; set; } = null!;

        public string Guess { get; set; } = null!;
        public bool GuessIsCorrect { get; set; }
        public DateTimeOffset GuessDate { get; set; }
        public int GuessNumber { get; set; }


    }
}

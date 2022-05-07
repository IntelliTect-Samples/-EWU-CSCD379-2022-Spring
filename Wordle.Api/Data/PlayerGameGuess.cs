namespace Wordle.Api.Data
{
    public class PlayerGameGuess
    {
        public int PlayerGameGuessId { get; set; }
        public int PlayerGameId { get; set; }
        public PlayerGame PlayerGame { get; set; } = null!;

        public string Guess { get; set; } = null!;
        public DateTime GetDate { get; set; }
    }
}

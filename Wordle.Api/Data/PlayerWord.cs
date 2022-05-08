namespace Wordle.Api.Data
{
    public class PlayerWord
    {
        public int PlayerWordId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;
        public PlayerWordState State { get; set; }


        public DateTimeOffset DateStarted { get; set; }
        public DateTimeOffset? DateEnded { get; set; }

        public ICollection<PlayerWordGuess> Guesses { get; set; } = null!;

        
        public enum PlayerWordState
        {
            Guessing = 0,
            Won = 1,
            Lost = 2,
            Abandoned = 3
        }
    }
}

namespace Wordle.Api.Data
{
    public class PlayerGame
    {
        public int PlayerGameId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;

        public DateTime DatePlayed { get; set; }
    }
}

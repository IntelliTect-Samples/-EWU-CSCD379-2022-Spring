namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<PlayerWord> Words { get; set; } = null!;
    }
}

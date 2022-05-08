namespace Wordle.Api.Data
{
    public class Word
    {
        public int WordId { get; set; }
        public string? Letters { get; set; }

        public ICollection<PlayerWord> PlayerWords { get; set; } = null!;
    }
}

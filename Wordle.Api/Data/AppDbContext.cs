

using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreStat> ScoreStats { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerWord> PlayerWords { get; set; } = null!;
        public DbSet<PlayerWordGuess> PlayerWordGuesss { get; set; } = null!;
        public DbSet<Word> Words { get; set; } = null!;
    }
}



using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreStat> ScoreStats => Set<ScoreStat>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<PlayerWord> PlayerWords => Set<PlayerWord>();
        public DbSet<PlayerWordGuess> PlayerWordGuesss => Set<PlayerWordGuess>();
        public DbSet<Word> Words => Set<Word>();
    }
}

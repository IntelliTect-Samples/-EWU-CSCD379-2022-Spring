using Wordle.Api.Data;
namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private AppDbContext _context;
        public PlayerService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Player> GetPlayers()
        {
            var result = _context.PlayerStats.OrderBy(p => p.AverageSecondsPerGame);
            return result;
        }
        public void Update(string name, int attempts, int seconds)
        {
            var player = _context.PlayerStats.First(p=>p.Name == name);
            if (player == null)
            {
                player = new Player();
                player.Name = name;
                player.AverageSecondsPerGame = seconds;
                player.AverageAttempts = attempts;
                player.GameCount = 1;
                _context.PlayerStats.Add(player);
            }
            player.AverageSecondsPerGame = (player.GameCount * player.AverageSecondsPerGame + seconds) / ++player.GameCount;
            player.AverageAttempts = (player.GameCount * player.AverageAttempts + attempts) / ++player.GameCount;
            _context.SaveChanges();
        }
        public static void Seed(AppDbContext context)
        {
            if (!context.PlayerStats.Any())
            {
                var player = new Player();
                player.Name = "Ray Tanner";
                player.AverageSecondsPerGame = 4;
                player.AverageAttempts = 1;
                player.GameCount = 200;
                context.PlayerStats.Add(player);
                context.SaveChanges();
            }
        }
    }
}

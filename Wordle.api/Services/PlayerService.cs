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
            var result = _context.PlayerStats.OrderBy(p => p.AverageSecondsPerGame).Take(10);
            return result;
        }
        public void Update(string name, int attempts, int seconds)
        {
            var player = _context.PlayerStats.FirstOrDefault(p=>p.Name == name);
            if (player == null)
            {
                player = new Player();
                player.Name = name;
                player.AverageSecondsPerGame = seconds;
                player.AverageAttempts = attempts;
                player.GameCount = 1;
                _context.PlayerStats.Add(player);
            }
            else
            {
                int oldGameCount = player.GameCount;
                player.GameCount++;
                player.AverageSecondsPerGame = (oldGameCount * player.AverageSecondsPerGame + seconds) / player.GameCount;
                player.AverageAttempts = (oldGameCount * player.AverageAttempts + attempts) / player.GameCount;
            }
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

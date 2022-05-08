using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerWordService
    {
        private readonly AppDbContext _db;

        public PlayerWordService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<PlayerWord> Start(string playerName, string letters)
        {
            var player = await GetPlayer(playerName);

            // See if there is a game going
            var playerWord = await _db.PlayerWords.FirstOrDefaultAsync(f =>
                f.PlayerId == player.PlayerId &&
                f.Word.Letters == letters &&
                f.State == PlayerWord.PlayerWordState.Guessing);

            // See if we need to age this one out
            if (playerWord != null && DateTime.Now - playerWord.DateStarted > TimeSpan.FromHours(1))
            {
                playerWord.State = PlayerWord.PlayerWordState.Abandoned;
                await _db.SaveChangesAsync();
                playerWord = null;
            }

            // Create a new one if we don't have one
            if (playerWord == null)
            {
                var word = await GetWord(letters);
                playerWord = new PlayerWord
                {
                    PlayerId = player.PlayerId,
                    WordId = word.WordId,
                    DateStarted = DateTime.Now,
                    State = PlayerWord.PlayerWordState.Guessing
                };
                _db.PlayerWords.Add(playerWord);
                await _db.SaveChangesAsync();
            }

            return playerWord;
        }

        /// <summary>
        /// Add a guess. Return true if correct.
        /// </summary>
        /// <param name="playerWordId"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Guess(int playerWordId, string guess)
        {
            var playerWord = await _db.PlayerWords
                .Include(f => f.Guesses)
                .Include(f => f.Word)
                .FirstOrDefaultAsync(f => f.PlayerWordId == playerWordId);
            if (playerWord == null) throw new Exception("PlayerWord not found");

            var playerWordGuess = new PlayerWordGuess
            {
                PlayerWordId = playerWordId,
                GuessDate = DateTime.Now,
                Guess = guess,
                GuessNumber = playerWord.Guesses.Count + 1,
                GuessIsCorrect = playerWord.Word.Letters == guess,
            };
            _db.PlayerWordGuesss.Add(playerWordGuess);

            if (playerWordGuess.GuessIsCorrect)
            {
                playerWord.State = PlayerWord.PlayerWordState.Won;
                playerWord.DateEnded = DateTimeOffset.Now;
            }

            await _db.SaveChangesAsync();

            return playerWordGuess.GuessIsCorrect;
        }

        /// <summary>
        /// Get the times a player has guessed a word.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="letters"></param>
        /// <returns></returns>
        public IQueryable<PlayerWord> GetPlayerWords(string playerName, string letters)
        {
            return _db.PlayerWords
                .Include(f => f.Guesses)
                .Where(f => f.Player.Name == playerName && f.Word.Letters == letters);
        }


        /// <summary>
        /// Gets or creates a player
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public async Task<Player> GetPlayer(string playerName)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == playerName);

            if (player == null)
            {
                player = new Player { Name = playerName };
                _db.Players.Add(player);
                await _db.SaveChangesAsync();
            }
            return player;
        }

        /// <summary>
        /// Gets or creates a word
        /// </summary>
        /// <param name="letters"></param>
        /// <returns></returns>
        public async Task<Word> GetWord(string letters)
        {
            var word = await _db.Words.FirstOrDefaultAsync(p => p.Letters == letters);

            if (word == null)
            {
                word = new Word { Letters = letters };
                _db.Words.Add(word);
                await _db.SaveChangesAsync();
            }
            return word;
        }
    }
}

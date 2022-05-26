﻿using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class DateWordService
    {
        private readonly AppDbContext _context;

        public DateWordService(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<DailyWordStatDto> GetLast10Words(string? name)
        {
            IEnumerable<DateWord> words;
            List<DailyWordStatDto> lastTen = new();

            int wordCount = _context.DateWords.Count();
            if (wordCount > 9)
            {
                words = _context.DateWords.OrderBy(x => x.Date).Take(10);
            }
            else
            {
                words = _context.DateWords.OrderBy(x => x.Date).Take(wordCount);
            }

            var player = _context.Players.Include(x => x.Games).First(x => x.Name == name);
            var games = player.Games.Select(x => x.DateStarted).ToList();

            foreach (var word in words)
            {
                DailyWordStatDto dto = new(word.Date, GetTotalPlays(word), GetAverageScore(word), GetAverageTime(word), GetHasPlayed(name, word));
                lastTen.Add(dto);
            }

            return lastTen;

        }

        public bool GetHasPlayed(string? name, DateWord word)
        {
            if (name == null)
            {
                return false;
            }
            var player = _context.Players.Include(x => x.Games).First(x => x.Name == name);

            foreach (var g in player.Games)
            {
                if (g.DateWordId == word.DateWordId)
                {
                    return true;
                }
            }

            return false;

        }

        public int GetTotalPlays(DateWord word)
        {
            int plays = _context.DateWords
                .Where(x => x == word)
                .Include(x => x.Games)
                .Count();

            return plays;
        }

        //TODO:Test
        public int GetAverageScore(DateWord word)
        {
            var scores = _context.DateWords
                    .Include(x => x.Games)
                    .ThenInclude(x => x.ScoreStat)
                    .Where(x => x.DateWordId == word.DateWordId)
                    .SelectMany(x => x.Games).ToList();


            var count = scores.ToList();
            List<int> listOfScores = new();

            foreach (var s in scores)
            {
                listOfScores.Add(s.ScoreStat!.Score);
            }
            int score = listOfScores.First();
            return (int)listOfScores.Average();
        }
        //TODO:Test
        public int GetAverageTime(DateWord word)
        {
            var scores = _context.DateWords
                    .Include(x => x.Games)
                    .ThenInclude(x => x.ScoreStat)
                    .Where(x => x.DateWordId == word.DateWordId)
                    .SelectMany(x => x.Games).ToList();


            List<int> listOfScores = new();

            foreach (var s in scores)
            {
                listOfScores.Add(s.ScoreStat!.Seconds);
            }

            return (int)listOfScores.Average();
        }

        public bool submitGame(DateTime date, string username, int score, int timeSeconds)
        {
            try
            {
                // find the dateword
                DateWord? currentDateWord = _context.DateWords
                    .Include(x => x.Games)
                    .Include(x => x.Players)
                    .First(x => x.Date == date);
                // if currentDateWord is null, the current days game has not been created 
                // previously and this game submission is wrong/malicious
                if (currentDateWord == null)
                {
                    // end here and do nothing with the game submission
                    return false;
                }

                // find player by username
                Player? currentPlayer = _context.Players
                    .Include(x => x.Games)
                    .First(x => x.Name == username);
                // if player not already in database, create a new player using submitted game stats
                if (currentPlayer == null)
                {
                    _context.Players.Add(new Player()
                    {
                        Name = username,
                        GameCount = 1,
                        AverageAttempts = score,
                        AverageSecondsPerGame = timeSeconds
                    });
                    // then reset currentPlayer reference to the newly created player
                    currentPlayer = _context.Players
                        .Include(x => x.Games)
                        .First(x => x.Name == username);
                }
                else
                {
                    //update that players stats
                    currentPlayer.AverageSecondsPerGame =
                        (currentPlayer.GameCount * currentPlayer.AverageSecondsPerGame + timeSeconds)
                        / (currentPlayer.GameCount + 1);

                    currentPlayer.AverageAttempts =
                        (currentPlayer.GameCount * currentPlayer.AverageAttempts + score)
                        / (currentPlayer.GameCount + 1);

                    currentPlayer.GameCount++;
                }

                // create a game object
                Game submittedGame = new Game()
                {
                    Player = currentPlayer,
                    DateWord = currentDateWord,
                    ScoreStat = new ScoreStat()
                    {
                        Score = score,
                        Seconds = timeSeconds
                    },
                    // There will be a difference between the aggregated DateStarted and DateEnded times 
                    // vs an individual Players AverageSecondsPerGame. By having the explicit field for
                    // AverageSecondsPerGame on the Player object we can reduce the DB calls that 
                    // would otherwise calculate the 'Actual' average from the list of Game objects
                    DateStarted = DateTime.Now.AddSeconds(-timeSeconds),// adding negative seconds
                    DateEnded = DateTime.Now,
                };

                // attach game to DateWord and Player
                currentDateWord.Games.Add(submittedGame);
                currentPlayer.Games.Add(submittedGame);

                // make sure save goes through (NOT async) before returning result
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                // catchall for exceptions resulting in savechanges not occouring
                // meaning function does not process and result is false 
                return false;
            }
        }
    }
}

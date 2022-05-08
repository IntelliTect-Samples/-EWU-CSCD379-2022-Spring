using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    public class DatabaseTestBase
    {
        protected AppDbContext _context;

        public DatabaseTestBase()
        {
            _context = GetContext();
            _context.Database.Migrate();
            ScoreStatsService.Seed(_context);
        }

        protected static AppDbContext GetContext()
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppDbContext(contextOptions.Options);
        }
    }
}
